using UnityEngine;

[CreateAssetMenu (menuName = "Weapon")]
public class WeaponModel : ScriptableObject
{
    public string weaponName;
    [TextArea] public string description;
    public int layerIndex;
    public WeaponMode weaponMode;
    public float impactForce;
    public  float damage;
    public  float range;
    public  float fireRate;
    public Sound weaponSound;
}