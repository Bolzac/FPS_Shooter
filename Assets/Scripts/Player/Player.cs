using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    
    public PlayerView playerView;
    public PlayerModel playerModel;
    public PlayerController playerController;
    public InputHandler inputHandler;
    public StateManager stateManager;
    public AudioManager soundManager;
    private void Awake()
    {
        SetCursor();
        cam = Camera.main;
        playerController = GetComponent<PlayerController>();
        inputHandler = GetComponent<InputHandler>();
        playerModel = GetComponent<PlayerModel>();
        stateManager = GetComponent<StateManager>();
        playerView = GetComponent<PlayerView>();
        soundManager = GetComponent<AudioManager>();
    }

    private void FixedUpdate()
    {
        SetHorizontalVelocity();
    }

    private void SetHorizontalVelocity()
    {
        if (playerModel.rb.velocity.x != 0 || playerModel.rb.velocity.z != 0)
        {
            playerModel.rb.velocity = Vector3.zero;
        }
    }

    private void SetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
