using UnityEngine;

[CreateAssetMenu(menuName = "Player/Inventory")]
public class InventoryState : State<Player>
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
    }

    public override void Update()
    {
        base.Update();
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