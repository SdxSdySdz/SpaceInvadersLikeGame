using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    private Mover _mover;
    private Vector2 _flyDirection;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move(_flyDirection);
    }

    public void Init(Vector2 flyDirection)
    {
        _flyDirection = flyDirection;
    }
}
