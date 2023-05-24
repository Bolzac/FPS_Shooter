using UnityEngine;

public class WeaponController : Handler<Player>
{
    public WeaponController(Player player) : base(player)
    {
    }

    public void SwayWeapon()
    {
        switch (runner.inputHandler.scrollWay)
        {
            case > 0 when runner.playerModel.weaponVariables.weaponRoot.childCount != runner.playerModel.weaponVariables.currentOrder + 1:
                HideWeapon();
                runner.playerModel.weaponVariables.currentOrder++;
                DrawWeapon();
                break;
            case < 0 when 0 != runner.playerModel.weaponVariables.currentOrder:
                HideWeapon();
                runner.playerModel.weaponVariables.currentOrder--;
                DrawWeapon();
                break;
        }
    }

    private void HideWeapon()
    {
        //Animate hide weapon animation for current weapon
        //Deactivate current weapon
        runner.playerModel.weaponVariables.weaponRoot.GetChild(runner.playerModel.weaponVariables.currentOrder).gameObject.SetActive(false);
    }

    private void DrawWeapon()
    {
        //Activate new order's weapon
        //Animate draw weapon animation for new order's weapon
        runner.playerModel.weaponVariables.weaponRoot.GetChild(runner.playerModel.weaponVariables.currentOrder).gameObject.SetActive(true);
    }

    private void EquipNewWeapon()
    {
        HideWeapon();
        runner.playerModel.weaponVariables.currentOrder = runner.playerModel.weaponVariables.weaponRoot.childCount - 1;
        DrawWeapon();
    }

    public void TakeWeapon(Transform weapon)
    {
        weapon.SetParent(runner.playerModel.weaponVariables.weaponRoot);
        weapon.localPosition = Vector3.zero;
        weapon.localRotation = Quaternion.Euler(Vector3.zero);
        EquipNewWeapon();
    }
}