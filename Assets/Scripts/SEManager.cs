using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private static SEManager instance;
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    public enum ClipName 
    {
        Shot,
        Explode,
        Hit,
        Don,
        Dondon,
        Fail,
        Success
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void Play(ClipName clipName) 
    {
        instance.audioSource.PlayOneShot(instance.clips[(int)clipName]);
    }
}
