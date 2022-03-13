using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightCommand : DistanceBasedMovingCommand
{
    protected override Vector2 Direction => Vector2.right;
}
