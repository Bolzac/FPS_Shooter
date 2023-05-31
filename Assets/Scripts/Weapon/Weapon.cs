using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private RaycastHit _raycastHit;
    private float _timer;
    private bool _canFire = true;

    public WeaponModel weaponModel;
    public ParticleSystem particle;

    // ReSharper disable Unity.PerformanceAnalysis
    public virtual void LeftClickAction(Player player)
    {
        switch (weaponModel.weaponMode)
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
        
        AnimateAndRaycast(player);

        yield return new WaitUntil(() =>
        {
            _timer += Time.deltaTime;
            return !player.inputHandler.mouseLeftClick && _timer >= weaponModel.fireRate;
        });
        _timer = 0;
        _canFire = true;
    }

    private void AutoFire(Player player)
    {
        if(!_canFire) return;
        
        AnimateAndRaycast(player);

        _canFire = false;
        Invoke(nameof(ResetFire),weaponModel.fireRate);
    }

    private void ResetFire()
    {
        _canFire = true;
    }

    private void CreateAndDesDetectObjectType(Impacts impacts)
    {
        Destroy(Instantiate(impacts.ImpactsByName[_raycastHit.transform.tag], _raycastHit.point, Quaternion.LookRotation(_raycastHit.normal)),impacts.impactDuration);
    }

    private void MakeNoiseOnShot(Player player)
    {
        player.playerModel.impacts.source.transform.position = _raycastHit.point;
        player.soundManager.PlayTargetAudio(player.playerModel.impacts.SoundsByName[_raycastHit.transform.tag],player.playerModel.impacts.source);
    }

    private void AnimateAndRaycast(Player player)
    {
        player.soundManager.PlayTargetAudio(weaponModel.weaponSound,player.playerModel.weaponVariables.source);
        player.animationManager.PlayTargetAnimation("Fire",player.playerModel.weaponVariables.currentWeapon.weaponModel.layerIndex);
        particle.Play(true);
        if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out _raycastHit, weaponModel.range))
        {
            if (_raycastHit.transform.CompareTag("Enemy"))
            {
                _raycastHit.transform.GetComponent<Enemy>().enemyController.HealthController.TakeDamage(weaponModel.damage);
            }else if (_raycastHit.rigidbody)
            {
                CreateAndDesDetectObjectType(player.playerModel.impacts);
                MakeNoiseOnShot(player);
                _raycastHit.rigidbody.AddForceAtPosition(player.cam.transform.forward * weaponModel.impactForce,_raycastHit.point,ForceMode.Impulse);
            }
        }
    }
}

public enum WeaponMode
{
    SINGLE,
    AUTO
}