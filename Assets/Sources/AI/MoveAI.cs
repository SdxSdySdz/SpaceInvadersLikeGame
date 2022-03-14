using UnityEngine;

public class MoveAI : AI<Transform>
{
    [SerializeField] private CommandsPerformer _commandsPerformer;

    public override void OnActivated()
    {
        _commandsPerformer.Perform(Target);
    }

    public override void OnDeactivated()
    {
        _commandsPerformer.Stop();
    }
}
