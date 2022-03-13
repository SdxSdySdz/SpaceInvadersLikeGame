using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DistanceBasedMovingCommand : MovingCommand
{
    [SerializeField] private float _distance;

    protected abstract Vector2 Direction { get; }
    protected override Vector2 Offset => _distance * Direction.normalized;
}
