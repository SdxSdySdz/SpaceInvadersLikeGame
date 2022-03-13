using UnityEngine;

public class MovingDownCommand : DistanceBasedMovingCommand
{
    protected override Vector2 Direction => Vector2.down;

}
