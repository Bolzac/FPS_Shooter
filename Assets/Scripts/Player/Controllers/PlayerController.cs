using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    public HandleMovement HandleMovement;
    public JumpHandler JumpHandler;
    public InteractionHandler InteractionHandler;
    public CrouchHandler CrouchHandler;
    public StaminaHandler StaminaHandler;
    public HealthHandler HealthHandler;
    public WeaponController WeaponController;

    private void Awake()
    {
        player = GetComponent<Player>();
        HandleMovement = new HandleMovement(player);
        JumpHandler = new JumpHandler(player);
        InteractionHandler = new InteractionHandler(player);
        CrouchHandler = new CrouchHandler(player);
        StaminaHandler = new StaminaHandler(player);
        HealthHandler = new HealthHandler(player);
        WeaponController = new WeaponController(player);
    }
}