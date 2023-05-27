using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public string description;
    public int layerIndex;
    [SerializeField] protected WeaponMode weaponMode;

    private RaycastHit _raycastHit;
    private float _timer;

    [SerializeField] private float impactForce;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    private bool _canFire = true;
    [SerializeField] private Transform muzzle;

    // ReSharper disable Unity.PerformanceAnalysis
    public virtual void LeftClickAction(Player player)
    {
        switch (weaponMode)
        {
            case WeaponMode.SINGLE:
                StartCoroutine(SingleFire(player));
                break;
            case WeaponMode.AUTO:
                AutoFire(player);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public virtual void RightClickAction(Player player){}

    private IEnumerator SingleFire(Player player)
    {
        if (!_canFire) yield break;
        _canFire = false;
        player.animationManager.PlayTargetAnimation("Fire",player.playerModel.weaponVariables.currentWeapon.layerIndex);
        if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out _raycastHit,
                range))
        {
            if (_raycastHit.rigidbody)
            {
                _raycastHit.rigidbody.AddForceAtPosition(player.cam.transform.forward * impactForce,_raycastHit.point,ForceMode.Impulse);
            }
        }

        yield return new WaitUntil(() =>
        {
            _timer += Time.deltaTime;
            return !player.inputHandler.mouseLeftClick && _timer >= fireRate;
        });
        _timer = 0;
        _canFire = true;
    }

    private void AutoFire(Player player)
    {
        if(!_canFire) return;
        player.animationManager.PlayTargetAnimation("Fire",player.playerModel.weaponVariables.currentWeapon.layerIndex);
        Debug.Log("a");
        if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out _raycastHit, range))
        {
            if (_raycastHit.rigidbody)
            {
                _raycastHit.rigidbody.AddForceAtPosition(player.cam.transform.forward * impactForce,_raycastHit.point,ForceMode.Impulse);
            }
        }

        _canFire = false;
        Invoke(nameof(ResetFire),fireRate);
    }

    private void ResetFire()
    {
        _canFire = true;
    }
}

public enum WeaponMode
{
    SINGLE,
    AUTO
}