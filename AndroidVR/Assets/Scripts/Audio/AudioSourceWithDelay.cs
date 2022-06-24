using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceWithDelay : MonoBehaviour
{
    [SerializeField]
    private float _delayDuration;

    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.Play();
        InvokeRepeating("PlayAudio", 1f,_audioSource.clip.length+_delayDuration);
    }

    private void PlayAudio()
    {
        _audioSource.Play();
    }


}
