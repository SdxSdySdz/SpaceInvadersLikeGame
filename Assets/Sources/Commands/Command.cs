using System;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public event Action Finished;

    public abstract void Perform(Transform target);

    protected void Finish()
    {
        Finished?.Invoke();
    }
}
