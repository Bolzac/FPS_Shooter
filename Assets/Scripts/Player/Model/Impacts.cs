using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Impacts
{
    public GameObject[] impacts;
    public string[] names;
    public Sound[] sounds;
    public AudioSource source;
    public Dictionary<string, GameObject> ImpactsByName;
    public Dictionary<string, Sound> SoundsByName;
    public float impactDuration;

    public void ListToDic()
    {
        ImpactsByName = new Dictionary<string, GameObject>();
        SoundsByName = new Dictionary<string, Sound>();
        for (var i = 0; i < names.Length; i++)
        {
            if (!ImpactsByName.ContainsKey(names[i]))
            {
                ImpactsByName.Add(names[i],impacts[i]);
            }
            if (!SoundsByName.ContainsKey(names[i]))
            {
                SoundsByName.Add(names[i],sounds[i]);
            }
        }
    }
}