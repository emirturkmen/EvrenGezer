using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio 
{
    [HideInInspector]
    public AudioSource source;

    public AudioClip clip;
    public string name;
    public bool loop;
    public float volume;
}
