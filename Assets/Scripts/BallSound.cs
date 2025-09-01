using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSound : MonoBehaviour
{
    public AudioClip[] ballSounds;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource.clip = ballSounds[0];
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground")) return;
        _audioSource.clip = ballSounds[Random.Range(0, ballSounds.Length)];
        _audioSource.volume = Mathf.Clamp01(other.relativeVelocity.magnitude / 20 * 2f);
        _audioSource.Play();
    }
}
