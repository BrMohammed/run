﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public string Name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volum;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    
}
