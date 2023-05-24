using System;
using UnityEngine;

[Serializable]
public class CrouchVariables
{
    [Range(0, 1)] public float crouchDuration;
    public Vector3 targetCrouchPosition;
    public Vector3 targetStandPosition;
}