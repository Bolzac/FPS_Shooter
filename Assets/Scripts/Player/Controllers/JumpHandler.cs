using UnityEngine;

public class JumpHandler : Handler<Player>
{
    private Vector3 _jumpDirection;

    public JumpHandler(Player player) : base(player)
    {
    }

    public void HandleJump()
    {
        _jumpDirection = runner.transform.up * runner.playerModel.jumpForce;
        runner.playerModel.rb.AddForce(_jumpDirection,ForceMode.Impulse);
    }
}