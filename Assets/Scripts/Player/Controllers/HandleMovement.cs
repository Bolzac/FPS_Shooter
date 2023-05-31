using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : BaseController<Player>
{
    private Vector3 _targetDirection;
    private Vector3 _moveDirection;
    public HandleMovement(Player player) : base(player)
    {
    }

    private void Move()
    {
        _moveDirection = Runner.cam.transform.forward * Runner.inputHandler.vertical;
        _moveDirection += Runner.cam.transform.right * Runner.inputHandler.horizontal;
        
        _moveDirection.Normalize();
        _moveDirection.y = 0;
    }

    public void Walk()
    {
        Move();
        if(Runner.inputHandler.vertical > 0) Runner.transform.position += _moveDirection * (Runner.playerModel.movementVariables.forwardWalkSpeed * Time.deltaTime);
        else if(Runner.inputHandler.vertical < 0) Runner.transform.position += _moveDirection * (Runner.playerModel.movementVariables.backwardWalkSpeed * Time.deltaTime);
        else Runner.transform.position += _moveDirection * (Runner.playerModel.movementVariables.strafeWalkSpeed * Time.deltaTime);
    }

    public void Run()
    {
        Move();
        if (Runner.inputHandler.crouchFlag) Runner.inputHandler.crouchFlag = false;
        Runner.transform.position += _moveDirection * (Runner.playerModel.movementVariables.forwardRunSpeed * Time.deltaTime);
    }

    public void CrouchWalk()
    {
        Move();
        Runner.transform.position += _moveDirection * (Runner.playerModel.movementVariables.forwardCrouchSpeed * Time.deltaTime);
    }
}