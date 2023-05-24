using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player player;
    public InteractionView InteractionView;
    public GroundView GroundView;

    private void Awake()
    {
        player = GetComponent<Player>();
        InteractionView = new InteractionView(player);
        GroundView = new GroundView(player);
    }
}