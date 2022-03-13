using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyArmy : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GridPlacer _placer;
    [SerializeField] private ShootAI _shootAI;
    [SerializeField] private EnemyPool _pool;

    private List<EnemyShip> _enemies;
    private Vector3 _placerStartPosition;

    private IEnumerable<Transform> Transforms => _enemies
        .Where(enemy => enemy.IsActive)
        .Select(enemy => enemy.transform);

    public event UnityAction AnyDied;
    public event UnityAction AllDied;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Debug.LogError("1");
        InstantiateAll();
        Debug.LogError("2");
        _placer.PlaceAsChilds(Transforms);
        Debug.LogError("3");
        _placerStartPosition = _placer.transform.position;
        Debug.LogError("4");
        _shootAI.Init(this);
        Debug.LogError("5");
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died.AddListener(OnEnemyDied);
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died.RemoveListener(OnEnemyDied);
        }
    }

    public void Restart()
    {
        DespawnAll();
        SpawnAll();
        // _placer.transform.position = _placerStartPosition;
    }

    public bool TryGetRandomEnemy(out EnemyShip enemy)
    {
        return _pool.TryGetRandomActiveObject(out enemy);
    }

    private void InstantiateAll()
    {
        if (_count < 1)
            throw new ArgumentOutOfRangeException(nameof(_count));

        _enemies = new List<EnemyShip>(_count);
        Debug.LogError("Lol");
        for (int i = 0; i < _count; i++)
        {
            Debug.LogError("Poop");
            Debug.LogError(_pool == null);
            Debug.LogError("looooooooooooool");
            if (_pool.TryGetObject(out EnemyShip enemy))
            {
                Debug.LogError("Ahahahah");
                enemy.Show();
                _enemies.Add(enemy);
            }
            else
            {
                Debug.LogError("Opa");
                throw new ArgumentOutOfRangeException(nameof(_count));

            }
        }
        Debug.LogError("Kek");
    }

    private void SpawnAll()
    {
        foreach (var poolObject in _enemies)
        {
            poolObject.Show();
        }
    }

    private void DespawnAll()
    {
        foreach (var poolObject in _enemies)
        {
            poolObject.Hide();
        }
    }

    private void OnEnemyDied()
    {
        AnyDied?.Invoke();

        if (_pool.AnyActivated == false)
            AllDied?.Invoke();
    }
}
