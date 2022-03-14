using System.Collections.Generic;
using UnityEngine;

public class CommandsPerformer : MonoBehaviour
{
    [SerializeField] private List<MovingCommand> _commands;

    private Transform _target;
    private int _commandIndex;

    public void Perform(Transform target)
    {
        _target = target;
        _commandIndex = _commands.Count - 1;
        OnCommandFinished();
    }

    public void Stop()
    {
        _target = null;
    }

    private void OnCommandFinished()
    {
        MovingCommand command = _commands[_commandIndex];
        command.Finished -= OnCommandFinished;

        if (_target == null)
            return;

        _commandIndex = (_commandIndex + 1) % _commands.Count;
        command = _commands[_commandIndex];

        command.Finished += OnCommandFinished;
        command.Perform(_target);
    }
}
