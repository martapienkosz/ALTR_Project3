using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCastle2 : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float duration = 15;
    
    public AudioSource platform2MoveSound;

    public GameObject castle2;

    float currentT = 0;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void movePlatform2()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {

        platform2MoveSound.Play();
        while (castle2.transform.position != end.position)
        { 
            currentT += Time.deltaTime / duration;
            currentT = Mathf.Clamp01(currentT);
            castle2.transform.position = Vector3.Lerp(start.position, end.position, curve.Evaluate(currentT));
            yield return null;
        }
        platform2MoveSound.Stop();
    }
}
