using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    public float cnt = 0.1f;

    public AudioSource npcDialogue;
    public Transform userLocation;

    public NavMeshAgent agent;
    public bool enableFollowing = false;
    public float interval = 1.0f;
    public FilesTriggerArea filestrigger;

    public Animator animator;

    float timer = 0;

    GameObject xrRig = null;

    public void Update()
    {
        if (xrRig == null)
        {
            xrRig = GameObject.FindWithTag("XRRig");
            if (xrRig == null) return;
        }

        if (enableFollowing)
        {
            //transform.LookAt(xrRig.transform);
            StartCoroutine(PlayDialogue());
            if (timer >= interval)
            {
                animator.SetBool("isWalking", true);

                Vector3 pos = xrRig.transform.position;
                pos.y = 0; //the floor
                agent.SetDestination(pos);

            }
            else
            {
                //agent.GetComponent<Animation>().Play("Standing");
                animator.SetBool("isWalking", false);
                timer += Time.deltaTime;
            }
        }

        IEnumerator PlayDialogue()
        {
            filestrigger.filesDialogue.Stop();
            while (!npcDialogue.isPlaying && cnt == 0.1f)
            {
                // transform.LookAt(userLocation.position, Vector3.up);
                npcDialogue.Play();
                cnt = 1.0f;
                yield return null;
            }
        }
    }
}

    //transform.LookAt(xrRig.transform);
    //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
    //{
    //    TargetDistance = Shot.distance;
    //    if (TargetDistance >= AllowedDistance)
    //    {
    //        FollowSpeed = 0.02f;
    //        transform.position = Vector3.MoveTowards(transform.position, xrRig.transform.position, FollowSpeed * Time.deltaTime);
    //    }
    //}
    //else
    //{
    //    FollowSpeed = 0;
    //    StartCoroutine(PlayDialogue());
    //}


//public void PlayNPCDialogue()
//{
//    if (GameObject.FindWithTag("XRRig").transform.position.x == minValue)
//    {
//        StartCoroutine(PlayDialogue());
//    }
//}
