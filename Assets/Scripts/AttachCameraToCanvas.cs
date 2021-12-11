using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttachCameraToCanvas : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        if(canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
