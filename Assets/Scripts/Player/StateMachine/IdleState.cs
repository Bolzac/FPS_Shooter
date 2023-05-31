using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Stand/Idle")]
public class IdleState : State<Player>
{
    private bool _playFirst;
    public override void Init(Player parent)
    {
        base.Init(parent);
    }

    public override void Enter()
    {
        base.Enter();
        Runner.animationManager.PlayTargetAnimation("Idle",Runner.playerModel.weaponVariables.currentWeapon.weaponModel.layerIndex);
        Runner.StartCoroutine(Runner.soundManager.PlayBreathing());
    }

    public override void CaptureInput()
    {
        base.CaptureInput();
        if (Runner.inputHandler.moveFlag)
        { 
            if(Runner.inputHandler.runFlag && Runner.playerModel.stamina.currentStamina > Runner.playerModel.stamina.pantingLimit) Runner.stateManager.SetState(typeof(RunState));
            else Runner.stateManager.SetState(typeof(WalkState));
        }
        else if(Runner.inputHandler.jumpFlag) Runner.stateManager.SetState(typeof(JumpState));
        else if (Runner.inputHandler.crouchFlag)
        {
            Runner.stateManager.SetState(typeof(CrouchIdleState));
            Runner.StartCoroutine(Runner.playerController.CrouchHandler.Crouch());
        }else if (Runner.inputHandler.interactionFlag) Runner.playerController.InteractionHandler.HandleInteraction();
        else if(Runner.inputHandler.mouseLeftClick) Runner.playerModel.weaponVariables.currentWeapon.LeftClickAction(Runner);
        else if(Runner.inputHandler.mouseRightClick) Runner.playerModel.weaponVariables.currentWeapon.RightClickAction(Runner);
    }

    public override void Update()
    {
        base.Update();
        Runner.playerView.InteractionView.DetectInteraction();
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
    }
}