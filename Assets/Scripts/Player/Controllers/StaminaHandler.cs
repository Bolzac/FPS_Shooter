using UnityEngine;
public class StaminaHandler : Handler<Player>
{
    private float _timer;

    
    public StaminaHandler(Player player) : base(player)
    {
    }
    
    public void DecreaseStamina()
    {
        if (runner.playerModel.stamina.currentStamina > 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                runner.playerModel.stamina.currentStamina -= runner.playerModel.stamina.decreaseAmount;
                SetStamina();
            }
        }
    }

    public void IncreaseStamina()
    {
        if (runner.playerModel.stamina.maximumStamina > runner.playerModel.stamina.currentStamina)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                runner.playerModel.stamina.currentStamina += runner.playerModel.stamina.increaseAmount;
                SetStamina();
            }
        }
    }

    private void SetStamina()
    {
        runner.playerModel.stamina.currentStamina = Mathf.Clamp(runner.playerModel.stamina.currentStamina, 0, runner.playerModel.stamina.maximumStamina);
    }
}