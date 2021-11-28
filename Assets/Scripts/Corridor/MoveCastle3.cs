using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCastle3 : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float duration = 15;

    public AudioSource platform3MoveSound;

    public GameObject castle3;

    float currentT = 0;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void movePlatform3()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        platform3MoveSound.Play();
        while (castle3.transform.position != end.position)
        {
            currentT += Time.deltaTime / duration;
            currentT = Mathf.Clamp01(currentT);
            castle3.transform.position = Vector3.Lerp(start.position, end.position, curve.Evaluate(currentT));
            yield return null;
        }
        platform3MoveSound.Stop();
    }
}

