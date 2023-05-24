using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Air/Jump")]
public class JumpState : State<Player>
{
    public override void Init(Player parent)
    {
        base.Init(parent);
    }

    public override void Enter()
    {
        base.Enter();
        Runner.playerModel.isOnGround = false;
        Runner.playerController.JumpHandler.HandleJump();
    }

    public override void CaptureInput()
    {
        base.CaptureInput();
    }

    public override void Update()
    {
        base.Update();
        Runner.playerController.HandleMovement.Walk();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void ChangeState()
    {
        base.ChangeState();
        if(Runner.playerModel.rb.velocity.y <= 0) Runner.stateManager.SetState(typeof(FallState));
    }

    public override void Exit()
    {
        base.Exit();
    }
}
