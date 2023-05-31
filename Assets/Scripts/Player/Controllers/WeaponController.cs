using UnityEngine;

public class WeaponController : BaseController<Player>
{
    public WeaponController(Player player) : base(player)
    {
    }

    public void SwayWeapon()
    {
        switch (Runner.inputHandler.scrollWay)
        {
            case > 0 when Runner.playerModel.weaponVariables.weaponRoot.childCount != Runner.playerModel.weaponVariables.currentOrder + 1:
                HideWeapon();
                Runner.playerModel.weaponVariables.currentOrder++;
                DrawWeapon();
                break;
            case < 0 when 0 != Runner.playerModel.weaponVariables.currentOrder:
                HideWeapon();
                Runner.playerModel.weaponVariables.currentOrder--;
                DrawWeapon();
                break;
        }
    }

    public void HideWeapon()
    {
        //Animate hide weapon animation for current weapon
        Runner.animationManager.animator.SetLayerWeight(Runner.playerModel.weaponVariables.currentWeapon.weaponModel.layerIndex,0); 
        Runner.playerModel.weaponVariables.currentWeapon.transform.parent.gameObject.SetActive(false);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    //Check for performance later
    public void DrawWeapon()
    {
        Runner.playerModel.weaponVariables.currentWeapon = Runner.playerModel.weaponVariables.weaponRoot
            .GetChild(Runner.playerModel.weaponVariables.currentOrder).GetChild(0).GetComponent<Weapon>();
        Runner.animationManager.animator.SetLayerWeight(Runner.playerModel.weaponVariables.currentWeapon.weaponModel.layerIndex,1);
        //Animate draw weapon animation for new order's weapon
        Runner.playerModel.weaponVariables.currentWeapon.transform.parent.gameObject.SetActive(true);
    }

    private void EquipNewWeapon()
    {
        HideWeapon();
        Runner.playerModel.weaponVariables.currentOrder = Runner.playerModel.weaponVariables.weaponRoot.childCount - 1;
        DrawWeapon();
    }

    public void TakeWeapon(Transform weapon)
    {
        weapon.SetParent(Runner.playerModel.weaponVariables.weaponRoot);
        weapon.localPosition = Vector3.zero;
        weapon.localRotation = Quaternion.Euler(Vector3.zero);
        EquipNewWeapon();
    }
}