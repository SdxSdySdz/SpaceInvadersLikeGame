using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private BulletPool _playerBulletPool;
    [SerializeField] private EnemyArmy _enemies;
    [SerializeField] private LosingZone _losingZone;

    [Header("UI")]
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _playerShip.Died += OnPlayerDied;
        _enemies.AnyDied += OnEnemyDied;
        _enemies.AllDied += OnAllEnemyDied;
        _losingZone.EnemyEntered += OnEnemyEnteredLosingZone;
    }

    private void OnDisable()
    {
        _playerShip.Died -= OnPlayerDied;
        _enemies.AnyDied -= OnEnemyDied;
        _enemies.AllDied -= OnAllEnemyDied;
        _losingZone.EnemyEntered -= OnEnemyEnteredLosingZone;

    }

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        PreparePlayer();
        PrepareEnemies();
        _playerBulletPool.HideAll();

        _score.Reset();
    }

    private void PreparePlayer()
    {
        _playerShip.Init(_playerBulletPool);
        _playerShip.transform.position = new Vector3(0, -4, 0);
    }

    private void PrepareEnemies()
    {
        _enemies.Restart();
    }

    private void OnPlayerDied()
    {
        Restart();
    }

    private void OnEnemyDied()
    {
        _score.Increment();
    }

    private void OnAllEnemyDied()
    {
        Restart();
    }

    private void OnEnemyEnteredLosingZone()
    {
        Restart();
    }
}
