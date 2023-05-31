using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public HealthController HealthController;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        HealthController = new HealthController(enemy);
    }
}
