using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float highlightSpeed = 15.0f;

    float currentHighlightAmount = 0.5f;


    public void StartHighlight()
    {
        StartCoroutine(Highlight(0.81f));
    }

    IEnumerator Highlight(float target)
    {
        while (Mathf.Approximately(currentHighlightAmount, target))
        {
            currentHighlightAmount = Mathf.MoveTowards(currentHighlightAmount, target, highlightSpeed * Time.deltaTime);

            skinnedMeshRenderer.material.SetFloat("_GlowAmount", currentHighlightAmount);

            yield return null;
        }
    }

}
