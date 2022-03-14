using UnityEngine;

public abstract class AI<TTarget> : MonoBehaviour
    where TTarget : class
{
    protected TTarget Target;

    public void Activate(TTarget enemies)
    {
        Target = enemies;
        OnActivated();
    }

    public void Deactivate()
    {
        Target = null;
        OnDeactivated();
    }

    public abstract void OnActivated();
    public abstract void OnDeactivated();

}
