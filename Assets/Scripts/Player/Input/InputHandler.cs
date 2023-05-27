using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerInput _playerInputs;

    [Header("Movement Values")]
    public float horizontal;
    public float vertical;
    
    [Header("Flags")]
    public bool moveFlag;
    public bool jumpFlag;
    public bool crouchFlag;
    public bool runFlag;
    public bool interactionFlag;
    public bool inventoryToggleFlag;
    public bool mouseLeftClick;
    public bool mouseRightClick;

    public float scrollWay;
    private void Awake()
    {
        _playerInputs = new PlayerInput();
    }
    
    private void OnEnable()
    {
        _playerInputs.Enable();

        #region Movement

        _playerInputs.Actions.Movement.performed += i =>
        {
            horizontal = i.ReadValue<Vector2>().x;
            vertical = i.ReadValue<Vector2>().y;
            moveFlag = i.ReadValue<Vector2>() != Vector2.zero;
        };

        #endregion

        _playerInputs.Actions.Jump.performed += i => jumpFlag = true;
        _playerInputs.Actions.Jump.canceled += i => jumpFlag = false;

        _playerInputs.Actions.Crouch.performed += i => crouchFlag = !crouchFlag;

        _playerInputs.Actions.Sprint.performed += i => { runFlag = !runFlag; };

        _playerInputs.Actions.Interaction.performed += i => interactionFlag = true;
        _playerInputs.Actions.Interaction.canceled += i => interactionFlag = false;

        _playerInputs.Actions.InventoryToggle.performed += i => inventoryToggleFlag = !inventoryToggleFlag;

        _playerInputs.Actions.Sway.performed += i => scrollWay = i.ReadValue<float>();

        _playerInputs.Actions.Left_Weapon.performed += i => mouseLeftClick = true;
        _playerInputs.Actions.Left_Weapon.canceled += i => mouseLeftClick = false;
    }
    
    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}