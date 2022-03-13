using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(ShipAudio))]
public abstract class Ship : MonoBehaviour
{
    [SerializeField] private Vector2 _shootDirection;
    [SerializeField] private Bullet _bulletPrefab;

    protected SpriteRenderer Renderer;
    protected CapsuleCollider2D Collider;

    public UnityEvent Shooted;
    public UnityEvent TookDamage;
    public UnityEvent Died;

    private void Awake()
    {
        if (_shootDirection == Vector2.zero)
            throw new ArgumentException(nameof(_shootDirection));

        Renderer = GetComponent<SpriteRenderer>();

        Collider = GetComponent<CapsuleCollider2D>();
        Collider.isTrigger = true;
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
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.Init(_shootDirection);

        Shooted?.Invoke();
    }

    protected abstract void OnTakeDamage();

    protected abstract void OnDie();
}
