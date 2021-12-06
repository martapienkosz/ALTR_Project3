using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public NPCController NPC;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("XRRig"))
        {
            NPC.enableFollowing = true;
        }
    }
}
