using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDissolve : MonoBehaviour
{
    //call this line from any script to fade the screen to black

    public void StartDissolve()
    {
        StartCoroutine(XRSceneTransitionManager.Instance.Fade(1.0f));
    }

}

