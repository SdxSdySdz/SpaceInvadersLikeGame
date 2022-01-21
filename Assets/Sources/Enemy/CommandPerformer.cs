using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommandPerformer : MonoBehaviour
{
    [SerializeField] private List<MovingCommand> _commands;

    private int _currentCommandIndex;

    private void Start()
    {
        _currentCommandIndex = 0;
        OnCommandFinished();
    }

    private void OnCommandFinished()
    {
        MovingCommand command = _commands[_currentCommandIndex];

        command.Finished -= OnCommandFinished;

        _currentCommandIndex = (_currentCommandIndex + 1) % _commands.Count;
        command = _commands[_currentCommandIndex];

        command.Finished += OnCommandFinished;
        command.Perform();
    }
}
