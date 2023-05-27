using System;
using UnityEngine;

[Serializable]
public class WeaponVariables
{
    public Transform weaponRoot;
    public Weapon currentWeapon;
    public int maxWeaponAmount;
    public int currentOrder;
    public int swayAmount;
}