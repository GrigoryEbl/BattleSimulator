using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayEffect()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position);
    }
}
