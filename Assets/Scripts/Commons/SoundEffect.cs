using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : PoolableObject
{
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
        StartCoroutine(StopAudioSource(clip.length));
    }

    IEnumerator StopAudioSource(float length) {
        yield return new WaitForSeconds(length);
        gameObject.SetActive(false);

    }


}
