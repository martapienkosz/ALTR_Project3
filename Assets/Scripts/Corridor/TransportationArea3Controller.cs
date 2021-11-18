using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationArea3Controller : MonoBehaviour
{
    public bool cnt3 = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Camera")
        {
            cnt3 = true;
        }
    }
}