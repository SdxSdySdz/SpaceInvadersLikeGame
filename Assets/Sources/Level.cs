using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private EnemyArmy _enemies;

    private void Start()
    {
        Restart();
    }

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

    public void Restart()
    {
        PreparePlayer();
        PrepareEnemies();
    }

    private void PreparePlayer()
    {
        _playerShip.transform.position = new Vector3(0, -4, 0);
    }

    private void PrepareEnemies()
    {
        _enemies.Restart();
    }

    private void OnEnemyDied()
    {

    }

    private void OnAllEnemyDied()
    {
        Restart();
    }
}
