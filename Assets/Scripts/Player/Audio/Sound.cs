using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    [Range(0,1f)] public float volume;
    [Range(0,3)] public float pitch;
    public float minDistance;
    public float maxDistance;
    public bool isLooping;
}