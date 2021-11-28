using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChanges : MonoBehaviour
{
    public Color colorStart = Color.blue;
    public Color colorEnd = Color.red;
    public float duration = 15.0f;

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_SkyGradientBottom", Color.Lerp(colorStart, colorEnd, lerp));
    }

    //IEnumerator Sunset(float target)
    //{
    //    while (Mathf.Approximately(currentContributionAmount, target))
    //    {
    //        currentContributionAmount = Mathf.MoveTowards(currentContributionAmount, target, speed * Time.deltaTime);

    //        sunset2.SetFloat("_HorizonLineContribution", currentContributionAmount);
    //        // "_HorizonLineContribution" 0.75 - 0; 135076; 0E334B

    //        yield return null;
    //    }
    //}
}