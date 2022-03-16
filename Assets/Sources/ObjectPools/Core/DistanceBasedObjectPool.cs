using UnityEngine;

public abstract class DistanceBasedObjectPool<TObject> : ObjectPool<TObject>
    where TObject : MonoBehaviour, IPoolable
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _distance;

    private void Update()
    {
        foreach (var poolObject in ActiveObjects)
        {
            var distance = Vector3.Distance(poolObject.transform.position, _point.position);
            if (distance > _distance)
                poolObject.Hide();
        }
    }
}
