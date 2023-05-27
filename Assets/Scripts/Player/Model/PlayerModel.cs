using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody rb;
    public CapsuleCollider col;

    public MovementVariables movementVariables;
    
    [Range(1, 5)] public float jumpForce;

    public CrouchVariables crouchVariables;
    
    [Range(0, 2)] public float interactionLength;
    public RaycastHit? InteractionObj;
    public LayerMask interactionMask;

    [Header("Ground View")] 
    public GroundType groundType;
    public Transform groundPoint;
    [Range(0, 0.5f)] public float groundDetectionLength;
    public bool isOnGround;

    public Health health;
    public Stamina stamina;
    public WeaponVariables weaponVariables;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
}