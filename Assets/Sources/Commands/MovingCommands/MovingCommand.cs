using System.Collections;
using UnityEngine;

public abstract class MovingCommand : Command
{
    [SerializeField] private float _duration;

    private Coroutine _movingCoroutine;

    protected abstract Vector2 Offset { get; }

    public override void Perform()
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(ApplyMoving());
    }

    private IEnumerator ApplyMoving()
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        Vector2 startPosition = transform.position;
        Vector2 endPosition = (Vector2)transform.position + Offset;

        float time = 0;
        while (time < _duration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, time / _duration);
            time += Time.deltaTime;
            yield return waitForEndOfFrame;
        }

        Finish();
    }
}
