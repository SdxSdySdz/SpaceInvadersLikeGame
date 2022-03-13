using UnityEngine;

public abstract class AI : MonoBehaviour
{
    protected EnemyArmy Enemies;

    public void Init(EnemyArmy enemies)
    {
        Enemies = enemies;
        OnInit();
    }

    public abstract void OnInit();
}
