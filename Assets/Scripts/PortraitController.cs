using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortraitController : MonoBehaviour
{

    public FrameHighlightController FrameHighlight;

    public AudioSource PortraitAudio;

    public UnityEvent OnFinished = new UnityEvent();

    bool hadStarted = false;

    public void playPortrait()
    {
        if (!hadStarted)
        {
            FrameHighlight.StartHighlight();
            PortraitAudio.Play();
            StartCoroutine(waitForAudioToEnd());
            hadStarted = true;
        }
    }

    IEnumerator waitForAudioToEnd()
    {
        yield return new WaitForSeconds(PortraitAudio.clip.length);
        FrameHighlight.StopHighlight();

        OnFinished.Invoke();
    }

}
