using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsPerformer : MonoBehaviour
{
    [SerializeField] private List<MovingCommand> _commands;

    private Coroutine _processCoroutine;

    public void Perform(Transform target)
    {
        Stop();

        _processCoroutine = StartCoroutine(PerfomProcesses(target));
    }

    public void Stop()
    {
        if (_processCoroutine != null)
            StopCoroutine(_processCoroutine);
    }

    private IEnumerator PerfomProcesses(Transform target)
    {
        for (int i = 0; i < _commands.Count; i = (i + 1) % _commands.Count)
        {
            yield return _commands[i].Process(target);
        }
    }
}
