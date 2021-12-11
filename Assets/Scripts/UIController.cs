using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject Canvas;

    public void deactivateCanvas()
    {
        StartCoroutine(HideCanvas());
    }

    IEnumerator HideCanvas()
    {
        Canvas.SetActive(false);
        yield return null;
    }
}