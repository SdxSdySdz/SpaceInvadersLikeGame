using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    [SerializeField] private Vector2 _shootDirection;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] protected float Speed;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.Init(_shootDirection);
    }
}
