using System;
using UnityEngine;

[Serializable]
public class Stamina
{
    public Sound[] sounds;
    public AudioSource source;
    [Range(0,100)] public float maximumStamina;
    [Range(0, 100)] public float currentStamina;
    [Range(0, 10)] public float decreaseAmount;
    [Range(0, 10)] public float increaseAmount;

    public float pantingLimit;
    public bool isPanting;
}