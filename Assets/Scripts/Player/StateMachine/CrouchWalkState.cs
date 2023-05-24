using UnityEngine;

[CreateAssetMenu(menuName = "Player/Crouch/Walk")]
public class CrouchWalkState : State<Player>
{
    private bool _isStandingUp;
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
        if(Runner.inputHandler.jumpFlag) Runner.stateManager.SetState(typeof(JumpState));
        else if(!Runner.inputHandler.moveFlag) Runner.stateManager.SetState(typeof(CrouchIdleState));
        else if (Runner.inputHandler.runFlag)
        {
            Runner.stateManager.SetState(typeof(RunState));
            Runner.inputHandler.crouchFlag = false;
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.StandUp());
        }else if (!Runner.inputHandler.crouchFlag)
        {
            Runner.stateManager.SetState(typeof(WalkState));
            Runner.inputHandler.crouchFlag = false;
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.StandUp());
        }
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.InteractionView.DetectInteraction();
        Runner.playerView.GroundView.DetectGround();
        Runner.playerController.HandleMovement.CrouchWalk();
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