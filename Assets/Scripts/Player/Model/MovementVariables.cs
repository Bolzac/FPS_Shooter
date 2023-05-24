using System;
using UnityEngine;
[Serializable]
public class MovementVariables
{
    [Range(1,5)] public float forwardWalkSpeed;
    [Range(1,5)] public float backwardWalkSpeed;
    [Range(1,5)] public float strafeWalkSpeed;
    [Range(1, 5)] public float forwardRunSpeed;
    [Range(1, 3)] public float forwardCrouchSpeed;
    public AudioSource movementSource;
    public Sound[] footStepSounds;
}