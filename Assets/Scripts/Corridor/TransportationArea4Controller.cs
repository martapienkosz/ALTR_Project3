using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationArea4Controller : MonoBehaviour
{
    public bool cnt4 = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRRig")
        {
            cnt4 = true;
        }
    }
}