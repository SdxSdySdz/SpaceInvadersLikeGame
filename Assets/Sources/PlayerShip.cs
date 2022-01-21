using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerShip : Ship
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _mover.Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void Update()
    {
        var moveDirection = Vector2.zero;
        var possibleMoveDirection = Vector2.right;

        if (Input.GetKey(KeyCode.A))
            moveDirection -= possibleMoveDirection;

        if (Input.GetKey(KeyCode.D))
            moveDirection += possibleMoveDirection;

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        _mover.Move(moveDirection);
    }
}
