using UnityEngine;

[RequireComponent(typeof(Timer))]
public class ShootAI : AI<EnemyArmy>
{
    [SerializeField] private Vector2 _periodRange;

    private Timer _timer;

    private float RandomPeriod => Random.Range(_periodRange.x, _periodRange.y);
    

    private void Awake()
    {
        if (_periodRange.y < _periodRange.x)
            throw new System.ArgumentException(nameof(_periodRange));

        _timer = GetComponent<Timer>();
        _timer.TimeIsUp += OnCooldownTimeIsUp;
    }

    public override void OnActivated()
    {
        _timer.Run(RandomPeriod);
    }

    public override void OnDeactivated()
    {
        _timer.Stop();
    }

    private void OnCooldownTimeIsUp()
    {
        if (Target.TryGetRandomEnemy(out EnemyShip enemy))
            enemy.Shoot();

        _timer.Run(RandomPeriod);
    }
}
