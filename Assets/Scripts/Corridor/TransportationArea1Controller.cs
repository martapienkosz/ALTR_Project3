using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationArea1Controller : MonoBehaviour
{
	public GameObject transportationarea1;
    public float cnt1;
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("XRRig"))
        {
		Debug.Log("is true");
		cnt1 = 1.0f;
        }
    }
}