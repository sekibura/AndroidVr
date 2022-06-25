using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceWithDelay : MonoBehaviour
{
    [SerializeField]
    private float _delayDuration;

    [SerializeField]
    private bool _randomTime;
    [SerializeField]
    private float _minTime;
    [SerializeField]
    private float _maxTime;


    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.Play();
        if (!_randomTime)
        {
            InvokeRepeating("PlayAudio", 1f, _audioSource.clip.length + _delayDuration);
        }
        else
        {
            StartCoroutine(PlayAudioWithRandomRepeat());
        }

    }

    private void PlayAudio()
    {
        _audioSource.Play();
    }

    private IEnumerator PlayAudioWithRandomRepeat()
    {
        float time = Random.Range(_audioSource.clip.length + _minTime, _audioSource.clip.length + _maxTime);
        yield return new WaitForSeconds(time);
        _audioSource.Play();
        StartCoroutine(PlayAudioWithRandomRepeat());
    }


}
