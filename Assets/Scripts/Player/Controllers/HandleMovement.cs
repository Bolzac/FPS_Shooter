using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : Handler<Player>
{
    private Vector3 _targetDirection;
    private Vector3 _moveDirection;
    public HandleMovement(Player player) : base(player)
    {
    }

    private void Move()
    {
        _moveDirection = runner.cam.transform.forward * runner.inputHandler.vertical;
        _moveDirection += runner.cam.transform.right * runner.inputHandler.horizontal;
        
        _moveDirection.Normalize();
        _moveDirection.y = 0;
    }

    public void Walk()
    {
        Move();
        if(runner.inputHandler.vertical > 0) runner.transform.position += _moveDirection * (runner.playerModel.movementVariables.forwardWalkSpeed * Time.deltaTime);
        else if(runner.inputHandler.vertical < 0) runner.transform.position += _moveDirection * (runner.playerModel.movementVariables.backwardWalkSpeed * Time.deltaTime);
        else runner.transform.position += _moveDirection * (runner.playerModel.movementVariables.strafeWalkSpeed * Time.deltaTime);
    }

    public void Run()
    {
        Move();
        if (runner.inputHandler.crouchFlag) runner.inputHandler.crouchFlag = false;
        runner.transform.position += _moveDirection * (runner.playerModel.movementVariables.forwardRunSpeed * Time.deltaTime);
    }

    public void CrouchWalk()
    {
        Move();
        runner.transform.position += _moveDirection * (runner.playerModel.movementVariables.forwardCrouchSpeed * Time.deltaTime);
    }
}