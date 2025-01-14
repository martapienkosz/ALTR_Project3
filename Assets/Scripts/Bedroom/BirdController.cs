using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BirdController : MonoBehaviour
{
    //private bool step1Start = false;
    //private bool step1Complete = false;
    //private bool step2Complete = false;
    //private bool step3Complete = false;


    // waterGrab first, portraitActive next

    public bool waterGrab;
    public bool waterExit;

    public bool portraitActive;
    public bool portraitDisactive;

    public Transform userLocation;

    public NavMeshAgent Agent;

    public Transform CTA_portriatLocation;
    public Transform CTA_leaveLocation;

    public AudioSource birdDialogue1;
    public AudioSource birdDialogue2;
    public AudioSource birdDialogue3;



    //reference to check whether each of the actions are complete
    //public checkWaterState waterState;
    //public checkPortraitState portraitState;

    AudioSource AudioClip;

    //IEnumerator Start()
    //{

    //    CTA_drink();

    //    yield return new WaitForSeconds(20);
    //    CTA_portrait();

    //    yield return WaitForBirdToReachDesitnation();

    //    yield return new WaitForSeconds(20);
    //    CTA_leave();
    //}


    private void Start()
    {
        CTA_drink();
    }


    public void CTA_drink()
    {
        birdDialogue1.Play();   

    }


    public void CTA_portrait()
    {

        Agent.SetDestination(CTA_portriatLocation.position);
        StartCoroutine(PlayBirdDialogue2());

    }

    public void CTA_leave()
    {

        Agent.SetDestination(CTA_leaveLocation.position);
        StartCoroutine(PlayBirdDialogue3());

    }

    IEnumerator PlayBirdDialogue2()
    {
        yield return WaitForBirdToReachDesitnation();

        birdDialogue2.Play();
    }

    IEnumerator PlayBirdDialogue3()
    {
        yield return WaitForBirdToReachDesitnation();

        transform.LookAt(userLocation.position, Vector3.up);

        birdDialogue3.Play();
    }


    IEnumerator WaitForBirdToReachDesitnation()
    {
        yield return new WaitForSeconds(0);

        while (Agent.pathPending) yield return null;

        while (Agent.remainingDistance > Agent.stoppingDistance)
        {
            yield return null;
        }
    }

    //IEnumerator AlignWith(Transform rotation)
    //{
    //    while(Vector3.Dot(transform.forward, rotation.forward) < 1.0)
    //    {
    //        transform.LookAt(rotation, rotation.position);
    //        yield return null;
    //    }
    //}
}
