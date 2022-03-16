using System.Collections;
using UnityEngine;

public abstract class MovingCommand : Command
{
    [SerializeField] private float _duration;

    protected abstract Vector2 Offset { get; }

    public IEnumerator Process(Transform target)
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        Vector2 startPosition = target.transform.position;
        Vector2 endPosition = (Vector2)target.transform.position + Offset;

        float time = 0;
        while (time < _duration)
        {
            target.transform.position = Vector2.Lerp(startPosition, endPosition, time / _duration);
            time += Time.deltaTime;
            yield return waitForEndOfFrame;
        }

        Finish();
    }
}
