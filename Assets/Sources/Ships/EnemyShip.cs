using UnityEngine;

public class EnemyShip : Ship, IPoolable
{
    public bool IsActive => enabled || Renderer.enabled || Collider.enabled;

    public void Show()
    {
        enabled = true;
        Renderer.enabled = true;
        Collider.enabled = true;
    }

    public void Hide()
    {
        enabled = false;
        Renderer.enabled = false;
        Collider.enabled = false;
    }

    protected override void OnTakeDamage()
    {
        Die();
    }

    protected override void OnDie()
    {
        Hide();
    }
}
