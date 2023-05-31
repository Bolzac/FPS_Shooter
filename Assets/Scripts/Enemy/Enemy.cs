using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyModel enemyModel;
    public EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }
}