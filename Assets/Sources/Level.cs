using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private EnemyArmy _enemies;
    [SerializeField] private BulletPool _playerBulletPool;

    [Header("UI")]
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _enemies.AnyDied += OnEnemyDied;
        _enemies.AllDied += OnAllEnemyDied;
    }

    private void OnDisable()
    {
        _enemies.AnyDied -= OnEnemyDied;
        _enemies.AllDied -= OnAllEnemyDied;
    }

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        PreparePlayer();
        PrepareEnemies();
        _score.Reset();
        _playerBulletPool.HideAll();
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

    private void OnEnemyDied()
    {
        _score.Increment();
    }

    private void OnAllEnemyDied()
    {
        Restart();
    }
}
