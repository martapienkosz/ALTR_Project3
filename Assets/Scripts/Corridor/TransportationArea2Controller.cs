using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationArea2Controller : MonoBehaviour
{
    public bool cnt2 = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRRig")
        {
            cnt2 = true;
        }
    }
}
