using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesTriggerArea : MonoBehaviour
{
    public AudioSource filesDialogue;
    public float cnt = 0.1f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("XRRig"))
        {
            StartCoroutine(PlayDialogue());
        }
    }

    IEnumerator PlayDialogue()
    {
        while (!filesDialogue.isPlaying && cnt == 0.1f)
        {
            // transform.LookAt(userLocation.position, Vector3.up);
            filesDialogue.Play();
            cnt = 1.0f;
            yield return null;
        }
    }
}
