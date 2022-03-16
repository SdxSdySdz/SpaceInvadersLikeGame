using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class LosingZone : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    public event UnityAction EnemyEntered;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.gravityScale = 0;

        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyShip enemy))
        {
            EnemyEntered?.Invoke();
        }
    }
}