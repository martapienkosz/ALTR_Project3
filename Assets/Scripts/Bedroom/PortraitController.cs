using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitController : MonoBehaviour
{
    bool portraitAudioEnabled = true;

    public AudioSource PortraitAudio1;
    public AudioSource PortraitAudio2;
    public AudioSource PortraitAudio3;

    Coroutine playAudioCoroutine;

    public void PlayPortraitAudio()
    {
        if (!portraitAudioEnabled) return;
        if (playAudioCoroutine != null)
        {
            StopCoroutine(playAudioCoroutine);
        }
        if (enabled)
            PortraitAudio1.Play();
    }

    public void StopPortraitAudio()
    {
        if (playAudioCoroutine != null)
        {
            StopCoroutine(playAudioCoroutine);
        }
        if (enabled)
            PortraitAudio1.Stop();

    }

    public void EnablePortraitAudio()
    {
        portraitAudioEnabled = true;
        //portraitAudioEnabled = true;
    }

    public void DisablePortraitAudio()
    {
        portraitAudioEnabled = false;
        //portraitAudioEnabled = false;
    }


}
