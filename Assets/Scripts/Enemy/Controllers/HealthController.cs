using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : BaseController<Enemy>
{
    public HealthController(Enemy source) : base(source)
    {
        Init();
    }
    public void TakeDamage(float damageAmount)
    {
        Runner.enemyModel.enemyHealth.currentHealth -= damageAmount;
        if (Runner.enemyModel.enemyHealth.currentHealth <= 0)
        {
            Runner.enemyModel.enemyHealth.isAlive = false;
        }
    }
    
    public void Init()
    {
        Runner.enemyModel.enemyHealth.currentHealth = Runner.enemyModel.enemyHealth.maxHealth;
    }
}
