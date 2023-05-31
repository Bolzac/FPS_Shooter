using UnityEngine;

public class JumpHandler : BaseController<Player>
{
    private Vector3 _jumpDirection;

    public JumpHandler(Player player) : base(player)
    {
    }

    public void HandleJump()
    {
        _jumpDirection = Runner.transform.up * Runner.playerModel.jumpForce;
        Runner.playerModel.rb.AddForce(_jumpDirection,ForceMode.Impulse);
    }
}