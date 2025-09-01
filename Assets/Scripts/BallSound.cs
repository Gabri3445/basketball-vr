using System;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioClip ballSound;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource.clip = ballSound;
    }

    private void OnCollisionEnter(Collision other)
    {
        _audioSource.volume = Mathf.Clamp01(other.relativeVelocity.magnitude / 20);
        _audioSource.Play();
    }
}
