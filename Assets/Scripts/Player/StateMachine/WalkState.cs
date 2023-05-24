using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Stand/Walk")]
public class WalkState : State<Player>
{
    public override void Init(Player parent)
    {
        base.Init(parent);
    }

    public override void Enter()
    {
        base.Enter();
        ChooseAndPlaySound();
        Runner.StartCoroutine(Runner.soundManager.PlayBreathing());
    }

    public override void CaptureInput()
    {
        base.CaptureInput();
        if (!Runner.playerModel.isOnGround) Runner.stateManager.SetState(typeof(FallState));
        else if (Runner.inputHandler.runFlag && Runner.playerModel.stamina.currentStamina > Runner.playerModel.stamina.pantingLimit ) Runner.stateManager.SetState(typeof(RunState));
        else if (!Runner.inputHandler.moveFlag) Runner.stateManager.SetState(typeof(IdleState));
        else if (Runner.inputHandler.jumpFlag) Runner.stateManager.SetState(typeof(JumpState));
        else if (Runner.inputHandler.crouchFlag)
        {
            Runner.stateManager.SetState(typeof(CrouchWalkState));
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.Crouch());
        }
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.InteractionView.DetectInteraction();
        Runner.playerView.GroundView.DetectGround();
        Runner.playerController.HandleMovement.Walk();
        Runner.playerController.StaminaHandler.IncreaseStamina();
        Runner.playerController.WeaponController.SwayWeapon();
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
        Runner.soundManager.StopTargetSource(Runner.playerModel.movementVariables.movementSource);
    }

    private void ChooseAndPlaySound()
    {
        switch (Runner.playerModel.groundType)
        {
            case GroundType.Grass:
                Runner.soundManager.PlayTargetAudio(Array.Find(Runner.playerModel.movementVariables.footStepSounds, sound => sound.name == "Walking On Grass" ),Runner.playerModel.movementVariables.movementSource);
                break;
            case GroundType.Wood:
                Runner.soundManager.PlayTargetAudio(Array.Find(Runner.playerModel.movementVariables.footStepSounds, sound => sound.name == "Walking On Wood" ),Runner.playerModel.movementVariables.movementSource);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}