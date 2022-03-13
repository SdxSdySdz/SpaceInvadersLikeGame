using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float? _period;
    private float _time;

    public UnityAction TimeIsUp;

    private void Awake()
    {
        _period = null;
    }

    private void Update()
    {
        if (_period == null)
            return;

        if (_time < _period.Value)
            _time += Time.deltaTime;
        else
        {
            _period = null;
            TimeIsUp?.Invoke();
        }
    }

    public void Run(float period)
    {
        _period = period;
        _time = 0;
    }
}
