using UnityEngine;

public class HealthHandler : Handler<Player>
{
    public void TakeDamage(float damageAmount)
    {
        runner.playerModel.health.currentHealth = damageAmount > runner.playerModel.health.currentHealth ? 0 : runner.playerModel.health.currentHealth - damageAmount;
    }

    public void Heal(float healAmount)
    {
        runner.playerModel.health.currentHealth += healAmount;
        runner.playerModel.health.currentHealth = Mathf.Clamp(runner.playerModel.health.currentHealth, 0,
            runner.playerModel.health.maxHealth);
    }

    public HealthHandler(Player player) : base(player)
    {
    }
}