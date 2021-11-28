using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FilesController : MonoBehaviour
{
    public AudioSource filesDialogue;
    public AudioClip filesClip;

    public void PlayFilesDialogue()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        while (!filesDialogue.isPlaying)
        {
            filesDialogue.PlayOneShot(filesClip);
            yield return null;
        }
    }
}
