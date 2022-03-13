using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;

    [SerializeField] private float _rowDistanceBetween;
    [SerializeField] private float _columnDistanceBetween;

    public int RowsCount => _size.x;
    public int ColumnsCount => _size.y;
    public int Capacity => RowsCount * ColumnsCount;

    public List<Transform> PlaceAsChilds(IEnumerable<Transform> transforms)
    {
        return Place(transforms, true);
    }

    public List<Transform> Place(IEnumerable<Transform> transformsCollection, bool asChilds)
    {
        List<Transform> transforms = transformsCollection.ToList();

        if (transforms.Count > Capacity)
            throw new ArgumentOutOfRangeException($"Impossible to place transforms");

        for (int row = 0; row < RowsCount; row++)
        {
            for (int column = 0; column < ColumnsCount; column++)
            {
                try
                {
                    int index = row * ColumnsCount + column;
                    transforms[index].position = transform.position + new Vector3(column * _columnDistanceBetween, row * _rowDistanceBetween, 0);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
        }

        if (asChilds)
        {
            foreach (var transform in transforms)
            {
                transform.SetParent(this.transform);
            }
        }

        return transforms;
    }
}