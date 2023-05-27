using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Stand/Run")]
public class RunState  : State<Player>
{
    public override void Init(Player parent)
    {
        base.Init(parent);
    }

    public override void Enter()
    {
        base.Enter();
        ChooseAndPlaySound();
        Runner.soundManager.PlayTargetAudio(Array.Find(Runner.playerModel.stamina.sounds, sound => sound.name == "While Running Breathing"),Runner.playerModel.stamina.source);
        Runner.playerController.WeaponController.HideWeapon();
    }

    public override void CaptureInput()
    {
        base.CaptureInput();
        if(!Runner.playerModel.isOnGround) Runner.stateManager.SetState(typeof(FallState));
        else if(!Runner.inputHandler.runFlag) Runner.stateManager.SetState(typeof(WalkState));
        else if(!Runner.inputHandler.moveFlag) Runner.stateManager.SetState(typeof(IdleState));
        else if(Runner.inputHandler.jumpFlag) Runner.stateManager.SetState(typeof(JumpState));
        else if(Runner.inputHandler.mouseLeftClick || Runner.inputHandler.mouseRightClick) Runner.stateManager.SetState(typeof(WalkState));
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.GroundView.DetectGround();
        Runner.playerController.HandleMovement.Run();
        Runner.playerController.StaminaHandler.DecreaseStamina();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void ChangeState()
    {
        base.ChangeState();
        if (Runner.playerModel.stamina.currentStamina <= 0)
        {
            Runner.stateManager.SetState(typeof(WalkState));
        }
    }

    public override void Exit()
    {
        base.Exit();
        Runner.playerController.WeaponController.DrawWeapon();
        Runner.soundManager.StopTargetSource(Runner.playerModel.movementVariables.movementSource);
        Runner.soundManager.StopTargetSource(Runner.playerModel.stamina.source);
        Runner.playerModel.stamina.isPanting = false;
    }
    
    private void ChooseAndPlaySound()
    {
        switch (Runner.playerModel.groundType)
        {
            case GroundType.Grass:
                Runner.soundManager.PlayTargetAudio(Array.Find(Runner.playerModel.movementVariables.footStepSounds, sound => sound.name == "Running On Grass" ),Runner.playerModel.movementVariables.movementSource);
                break;
            case GroundType.Wood:
                Runner.soundManager.PlayTargetAudio(Array.Find(Runner.playerModel.movementVariables.footStepSounds, sound => sound.name == "Running On Wood" ),Runner.playerModel.movementVariables.movementSource);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
