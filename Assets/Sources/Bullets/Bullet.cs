using System;
using UnityEngine;

public abstract class Bullet<TTarget> : Bullet
    where TTarget : Ship
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TTarget target))
        {
            target.TakeDamage();
            Hide();
        }
    }
}

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Collider2D))]
public abstract class Bullet : MonoBehaviour, IPoolable
{
    private Mover _mover;
    private Vector2 _flyDirection;
    private Collider2D _collider;

    public bool IsActive => gameObject.activeSelf;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _collider = GetComponent<Collider2D>();

        _collider.isTrigger = true;
    }

    private void Update()
    {
        _mover.Move(_flyDirection);
    }

    public void Init(Vector2 flyDirection)
    {
        _flyDirection = flyDirection;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}



