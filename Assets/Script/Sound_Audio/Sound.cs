using UnityEngine.Audio;
using UnityEngine;

// This script is used toghether.
[System.Serializable]
public class Sound
{
    public string name;

    public int id;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
