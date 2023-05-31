using System.Collections;
using UnityEngine;

public class CrouchHandler : BaseController<Player>
{
    private float _timer;
    private Transform _cameraChild;
    public CrouchHandler(Player player) : base(player)
    {
        _cameraChild = Runner.transform.Find("Camera");
    }

    public IEnumerator Crouch()
    {
        while (_timer < Runner.playerModel.crouchVariables.crouchDuration)
        {
            _timer += Time.deltaTime;
            _cameraChild.localPosition = Vector3.Lerp(Runner.playerModel.crouchVariables.targetStandPosition,
                Runner.playerModel.crouchVariables.targetCrouchPosition, _timer / Runner.playerModel.crouchVariables.crouchDuration);
            yield return null;
        }
        _cameraChild.localPosition = Runner.playerModel.crouchVariables.targetCrouchPosition;
        _timer = 0;
    }

    public IEnumerator StandUp()
    {
        
        while (_timer < Runner.playerModel.crouchVariables.crouchDuration)
        {
            _timer += Time.deltaTime;
            _cameraChild.localPosition = Vector3.Lerp(Runner.playerModel.crouchVariables.targetCrouchPosition,
                Runner.playerModel.crouchVariables.targetStandPosition, _timer / Runner.playerModel.crouchVariables.crouchDuration);
            yield return null;
        }
        _cameraChild.localPosition = Runner.playerModel.crouchVariables.targetStandPosition;
        _timer = 0;
    }
}