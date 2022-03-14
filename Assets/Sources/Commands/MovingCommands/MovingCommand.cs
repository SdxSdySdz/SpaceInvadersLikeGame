using System.Collections;
using UnityEngine;

public abstract class MovingCommand : Command
{
    [SerializeField] private float _duration;

    private Coroutine _movingCoroutine;

    protected abstract Vector2 Offset { get; }

    public override void Perform(Transform target)
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(ApplyMoving(target));
    }

    private IEnumerator ApplyMoving(Transform target)
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
