using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class OneShotAudioSource : MonoBehaviour
{
    private float timeToPlay;
    private bool initialized = false;
    [SerializeField] private AudioSource audioSource;

    public void Initialize(AudioClip clip, AudioMixerGroup mixerGroup)
    {
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.Play();
        timeToPlay = clip.length;
        StartCoroutine(DestroyAfterClipDone());
    }

    private IEnumerator DestroyAfterClipDone() {
        yield return new WaitForSeconds(timeToPlay);
        Destroy(this);
    }
}
