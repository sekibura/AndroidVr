using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioWithDelay : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] _sounds;

    [SerializeField]
    private float _minDelay;
    [SerializeField]
    private float _maxDelay;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.playOnAwake = false;
        StartCoroutine(PlayRandomSound());
    }

    private IEnumerator PlayRandomSound()
    {
        int num = Random.Range(0, _sounds.Length);
        float delay = Random.Range(_minDelay + _sounds[num].length, _maxDelay + _sounds[num].length);
        yield return new WaitForSeconds(delay);
        _audioSource.clip = _sounds[num];
        _audioSource.Play();
        StartCoroutine(PlayRandomSound());

    }
}
