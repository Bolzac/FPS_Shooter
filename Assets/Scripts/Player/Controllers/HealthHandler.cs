using UnityEngine;

public class HealthHandler : BaseController<Player>
{
    public void TakeDamage(float damageAmount)
    {
        Runner.playerModel.health.currentHealth = damageAmount > Runner.playerModel.health.currentHealth ? 0 : Runner.playerModel.health.currentHealth - damageAmount;
    }

    public void Heal(float healAmount)
    {
        Runner.playerModel.health.currentHealth += healAmount;
        Runner.playerModel.health.currentHealth = Mathf.Clamp(Runner.playerModel.health.currentHealth, 0,
            Runner.playerModel.health.maxHealth);
    }

    public HealthHandler(Player player) : base(player)
    {
    }
}