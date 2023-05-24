using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionView : View<Player>
{
    private Ray _ray;
    private RaycastHit _raycastHit;
    private bool _isDetected;

    public InteractionView(Player player) : base(player)
    {
    }

    public void DetectInteraction()
    {
        if (Physics.Raycast(runner.cam.transform.position, runner.cam.transform.forward, out _raycastHit, runner.playerModel.interactionLength,runner.playerModel.interactionMask))
        {
            if (!_isDetected)
            {
                runner.playerModel.InteractionObj = _raycastHit;
                _isDetected = true;
            }
        }
        else SetInteractionFalse();
    }

    private void SetInteractionFalse()
    {
        _isDetected = false;
        runner.playerModel.InteractionObj = null;
    }

}