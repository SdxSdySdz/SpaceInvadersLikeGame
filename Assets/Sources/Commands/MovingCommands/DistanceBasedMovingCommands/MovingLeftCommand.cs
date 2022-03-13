using UnityEngine;

public class MovingLeftCommand : DistanceBasedMovingCommand
{
    protected override Vector2 Direction => Vector2.left;
}
