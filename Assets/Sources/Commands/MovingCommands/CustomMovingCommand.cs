using UnityEngine;

public class CustomMovingCommand : MovingCommand
{
    [SerializeField] private Vector2 _offset;

    protected override Vector2 Offset => _offset;
}
