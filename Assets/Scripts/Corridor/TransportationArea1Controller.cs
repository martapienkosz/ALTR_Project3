using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationArea1Controller : MonoBehaviour
{
    public bool cnt1 = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Camera")
        {
            cnt1 = true;
        }
    }
}

