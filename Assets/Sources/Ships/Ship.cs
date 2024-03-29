using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(ShipAudio))]
public abstract class Ship : MonoBehaviour
{
    [SerializeField] private Vector2 _shootDirection;


    private BulletPool _bulletPool;

    protected CapsuleCollider2D Collider;

    private bool IsInitialized => _bulletPool != null;

    public event UnityAction Shooted;
    public event UnityAction TookDamage;
    public event UnityAction Died;

    private void Awake()
    {
        if (_shootDirection == Vector2.zero)
            throw new ArgumentException(nameof(_shootDirection));

        Collider = GetComponent<CapsuleCollider2D>();
        Collider.isTrigger = true;
    }

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void TakeDamage()
    {
        OnTakeDamage();
        TookDamage?.Invoke();
    }

    public void Die()
    {
        OnDie();
        Died?.Invoke();
    }

    public void Shoot()
    {
        if (IsInitialized == false)
            throw new Exception("Impossible to shoot. Bullet pool is not stated");

        if (_bulletPool.TryGetObject(out Bullet bullet) == false)
            throw new Exception("Impossible to spawn bullet");

        bullet.Show();
        bullet.transform.position = transform.position;
        bullet.Init(_shootDirection);

        Shooted?.Invoke();     
    }

    protected abstract void OnTakeDamage();

    protected abstract void OnDie();
}
