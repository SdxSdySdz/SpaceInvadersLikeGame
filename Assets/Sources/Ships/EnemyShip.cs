using UnityEngine;

public class EnemyShip : Ship, IPoolable
{
    public bool IsActive => enabled || Renderer.enabled || Collider.enabled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerShip target))
        {
            target.Die();
        }
    }

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
