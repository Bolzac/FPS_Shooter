public class InteractionHandler : BaseController<Player>
{
    public InteractionHandler(Player player) : base(player)
    {
    }

    public void HandleInteraction()
    {
        if (Runner.playerModel.InteractionObj.HasValue)
        {
            if (Runner.playerModel.InteractionObj.Value.transform.CompareTag("Weapon"))
            {
                Runner.playerController.WeaponController.TakeWeapon(Runner.playerModel.InteractionObj.Value.transform);
            }
        }
    }
}