using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyArmy : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GridPlacer _placer;
    [SerializeField] private ShootAI _shootAI;
    [SerializeField] private MoveAI _moveAI;

    [Header("Pools")]
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private List<EnemyShip> _enemies;
    private Vector3 _placerStartPosition;

    private IEnumerable<Transform> Transforms => _enemies
        .Where(enemy => enemy.IsActive)
        .Select(enemy => enemy.transform);

    public event UnityAction AnyDied;
    public event UnityAction AllDied;

    private void Awake()
    {
        _enemies = new List<EnemyShip>();
        _placerStartPosition = _placer.transform.position;
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void Start()
    {
        InstantiateAll(); 
        OnEnable();

        _placer.PlaceAsChilds(Transforms);
    }

    public void Restart()
    {
        _placer.transform.position = _placerStartPosition;

        DeactivateAIs();

        DespawnAll();
        _bulletPool.HideAll();

        SpawnAll();

        ActivateAIs();
    }

    public bool TryGetRandomEnemy(out EnemyShip enemy)
    {
        return _enemyPool.TryGetRandomActiveObject(out enemy);
    }

    private void InstantiateAll()
    {
        if (_count < 1)
            throw new ArgumentOutOfRangeException(nameof(_count));

        _enemies = new List<EnemyShip>(_count);
        for (int i = 0; i < _count; i++)
        {
            if (_enemyPool.TryGetObject(out EnemyShip enemy))
            {
                enemy.Show();
                enemy.Init(_bulletPool);
                _enemies.Add(enemy);
            }
            else
            {
                Debug.LogError(_enemies.Capacity);
                Debug.LogError(_enemies.Count);
                throw new ArgumentOutOfRangeException(nameof(_count));
            }
        }
    }

    private void OnEnemyDied()
    {
        AnyDied?.Invoke();

        if (_enemyPool.AnyActivated == false)
        {
            _bulletPool.HideAll();
            DeactivateAIs();
            AllDied?.Invoke();
        }
            
    }

    private void DespawnAll()
    {
        foreach (var poolObject in _enemies)
        {
            poolObject.Hide();
        }
    }

    private void SpawnAll()
    {
        foreach (var poolObject in _enemies)
        {
            poolObject.Show();
        }
    }

    private void DeactivateAIs()
    {
        _shootAI.Deactivate();
        _moveAI.Deactivate();
    }

    private void ActivateAIs()
    {
        _shootAI.Activate(this);
        _moveAI.Activate(_placer.transform);
    }
}
