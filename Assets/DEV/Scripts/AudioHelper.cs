using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip collectAudio;
    [SerializeField] AudioClip danceAudio;

    public void PlayCollectSound()
    {
        source.PlayOneShot(collectAudio);
    }
    public void PlayDanceSound()
    {
        source.PlayOneShot(danceAudio);
    }
    public void Stop()
    {
        source.Stop();
    }
}
