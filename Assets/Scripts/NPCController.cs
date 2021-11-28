using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    public AudioSource npcDialogue;
    public AudioClip npcClip;

    public void PlayNPCDialogue()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
    while (!npcDialogue.isPlaying)
    {
        npcDialogue.PlayOneShot(npcClip);
        yield return null;
    }
    }
}

