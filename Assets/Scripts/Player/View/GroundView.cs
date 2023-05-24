using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundView : View<Player>
{
    private Ray _ray;
    private RaycastHit _raycastHit;
    public GroundView(Player player) : base(player)
    {
    }

    public void DetectGround()
    {
        if (Physics.Raycast(runner.playerModel.groundPoint.position, -runner.playerModel.groundPoint.up, out _raycastHit, runner.playerModel.groundDetectionLength))
        {
            runner.playerModel.isOnGround = true;
            if (_raycastHit.transform.CompareTag("Wood")) runner.playerModel.groundType = GroundType.Wood;
        }else runner.playerModel.isOnGround = false;
    }
}

public enum GroundType
{
    Grass,
    Wood
}