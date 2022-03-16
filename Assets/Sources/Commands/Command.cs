using System;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public event Action Finished;

    protected void Finish()
    {
        Finished?.Invoke();
    }
}
