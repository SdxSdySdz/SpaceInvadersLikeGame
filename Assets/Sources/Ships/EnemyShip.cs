using UnityEngine;

public class EnemyShip : Ship, IPoolable
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _deathEffect;
    
    public bool IsActive => enabled || _renderer.enabled || Collider.enabled;

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
        _renderer.enabled = true;
        Collider.enabled = true;
    }

    public void Hide()
    {
        enabled = false;
        _renderer.enabled = false;
        Collider.enabled = false;
    }

    protected override void OnTakeDamage()
    {
        Die();
    }

    protected override void OnDie()
    {
        Hide();
        PlayDeathEffect();
    }

    private void PlayDeathEffect()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }
}
