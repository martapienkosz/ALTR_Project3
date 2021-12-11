using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesTriggerArea : MonoBehaviour
{
    public AudioSource filesDialogue;
    public float cnt = 0.1f;
    public bool npc = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("XRRig"))
        {
            StartCoroutine(PlayDialogue());
        }
    }

    IEnumerator PlayDialogue()
    {
        while (!filesDialogue.isPlaying && cnt == 0.1f && npc == false)
        {
            if(npc == true)
            {
                filesDialogue.Stop();
            }
 
            filesDialogue.Play();
            cnt = 1.0f;
            yield return null;
            
        }
    }
}
