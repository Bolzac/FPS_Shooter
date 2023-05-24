using System;
using UnityEngine;

[Serializable]
public class Health
{
    [Range(0,100)] public float maxHealth;
    [Range(0,100)] public float currentHealth;
}