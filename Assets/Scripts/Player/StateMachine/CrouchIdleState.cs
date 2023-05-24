using UnityEngine;

[CreateAssetMenu(menuName = "Player/Crouch/Idle")]
public class CrouchIdleState : State<Player>
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
        if (Runner.inputHandler.moveFlag)
        {
            if (Runner.inputHandler.runFlag)
            {
                Runner.inputHandler.crouchFlag = false;
                Runner.StartCoroutine(Runner.playerController.CrouchHandler.StandUp());
                Runner.stateManager.SetState(typeof(RunState));
            }else Runner.stateManager.SetState(typeof(CrouchWalkState));
        }
        else if (Runner.inputHandler.jumpFlag)
        {
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.StandUp());
            Runner.inputHandler.crouchFlag = false;
            Runner.stateManager.SetState(typeof(JumpState));
        }else if (!Runner.inputHandler.crouchFlag)
        {
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.StandUp());
            Runner.stateManager.SetState(typeof(IdleState));
        }
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.InteractionView.DetectInteraction();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
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