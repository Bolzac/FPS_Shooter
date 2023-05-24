using System.Collections;
using UnityEngine;

public class CrouchHandler : Handler<Player>
{
    private float _timer;
    private Transform _cameraChild;
    public CrouchHandler(Player player) : base(player)
    {
        _cameraChild = runner.transform.Find("Camera");
    }

    public IEnumerator Crouch()
    {
        while (_timer < runner.playerModel.crouchVariables.crouchDuration)
        {
            _timer += Time.deltaTime;
            _cameraChild.localPosition = Vector3.Lerp(runner.playerModel.crouchVariables.targetStandPosition,
                runner.playerModel.crouchVariables.targetCrouchPosition, _timer / runner.playerModel.crouchVariables.crouchDuration);
            yield return null;
        }
        _cameraChild.localPosition = runner.playerModel.crouchVariables.targetCrouchPosition;
        _timer = 0;
    }

    public IEnumerator StandUp()
    {
        
        while (_timer < runner.playerModel.crouchVariables.crouchDuration)
        {
            _timer += Time.deltaTime;
            _cameraChild.localPosition = Vector3.Lerp(runner.playerModel.crouchVariables.targetCrouchPosition,
                runner.playerModel.crouchVariables.targetStandPosition, _timer / runner.playerModel.crouchVariables.crouchDuration);
            yield return null;
        }
        _cameraChild.localPosition = runner.playerModel.crouchVariables.targetStandPosition;
        _timer = 0;
    }
}