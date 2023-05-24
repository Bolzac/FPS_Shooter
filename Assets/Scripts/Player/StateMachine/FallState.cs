using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Air/Fall")]
public class FallState : State<Player>
{
    public override void Init(Player parent)
    {
        base.Init(parent);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void CaptureInput()
    {
        base.CaptureInput();
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.GroundView.DetectGround();
        Runner.playerController.HandleMovement.Walk();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(Runner.playerModel.isOnGround) Runner.stateManager.SetState(typeof(IdleState));
    }

    public override void ChangeState()
    {
        base.ChangeState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
