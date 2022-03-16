using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<TObject> : MonoBehaviour
    where TObject : MonoBehaviour, IPoolable
{
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] protected TObject Prefab;
    [SerializeField] protected int Capacity;

    private List<TObject> _pool;

    private int ActiveCount => ActiveObjects.Count();

    protected IEnumerable<TObject> ActiveObjects => _pool.Where(poolObject => poolObject.IsActive);

    public bool AnyActivated => _pool.Any(poolObject => poolObject.IsActive);

    protected virtual void Awake()
    {
        SpawnObjects();
    }

    public bool TryGetRandomActiveObject(out TObject obj)
    {
        bool any = AnyActivated;
        obj = any ? ActiveObjects.ElementAt(Random.Range(0, ActiveCount)) : null;

        return any;
    }

    public bool TryGetObject(out TObject obj)
    {
        obj = _pool.FirstOrDefault(poolObject => poolObject.IsActive == false);
        return obj != null;
    }

    public void HideAll()
    {
        foreach (var poolObject in _pool)
        {
            poolObject.Hide();
        }
    }

    private void SpawnObjects()
    {
        _pool = new List<TObject>();
        for (int i = 0; i < Capacity; i++)
        {
            TObject obj = Instantiate(Prefab, _spawnPoint.position, Quaternion.identity);
            obj.Hide();

            _pool.Add(obj);
        }
    }
}
