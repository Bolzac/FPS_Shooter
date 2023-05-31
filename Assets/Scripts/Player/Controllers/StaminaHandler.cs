using UnityEngine;
public class StaminaHandler : BaseController<Player>
{
    private float _timer;

    
    public StaminaHandler(Player player) : base(player)
    {
    }
    
    public void DecreaseStamina()
    {
        if (Runner.playerModel.stamina.currentStamina > 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                Runner.playerModel.stamina.currentStamina -= Runner.playerModel.stamina.decreaseAmount;
                SetStamina();
            }
        }
    }

    public void IncreaseStamina()
    {
        if (Runner.playerModel.stamina.maximumStamina > Runner.playerModel.stamina.currentStamina)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                Runner.playerModel.stamina.currentStamina += Runner.playerModel.stamina.increaseAmount;
                SetStamina();
            }
        }
    }

    private void SetStamina()
    {
        Runner.playerModel.stamina.currentStamina = Mathf.Clamp(Runner.playerModel.stamina.currentStamina, 0, Runner.playerModel.stamina.maximumStamina);
    }
}