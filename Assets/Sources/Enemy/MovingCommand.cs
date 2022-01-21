using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingCommand : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _duration;

    private Rigidbody2D _rigidbody;
    private Coroutine _movingCoroutine;

    public event UnityAction Finished;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Perform()
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(ApplyMoving());
    }

    private IEnumerator ApplyMoving()
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        float speed = _offset.magnitude / _duration;
        Vector2 targetPosition = _rigidbody.position + _offset;
        while (_rigidbody.position != targetPosition)
        {
            _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, targetPosition, speed * Time.deltaTime);

            yield return waitForEndOfFrame;
        }

        Finished?.Invoke();
    }
}
