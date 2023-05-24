using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : Handler<Player>
{
    public InteractionHandler(Player player) : base(player)
    {
    }

    public void HandleInteraction()
    {
        if (runner.playerModel.InteractionObj.HasValue)
        {
            if (runner.playerModel.InteractionObj.Value.transform.CompareTag("Weapon"))
            {
                runner.playerController.WeaponController.TakeWeapon(runner.playerModel.InteractionObj.Value.transform);
            }
        }
    }
}
