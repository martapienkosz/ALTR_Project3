using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCastle5 : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float duration = 15;

    public AudioSource platform5MoveSound;

    public GameObject castle5;

    float currentT = 0;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void movePlatform5()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        platform5MoveSound.Play();
        while (castle5.transform.position != end.position)
        {
            currentT += Time.deltaTime / duration;
            currentT = Mathf.Clamp01(currentT);
            castle5.transform.position = Vector3.Lerp(start.position, end.position, curve.Evaluate(currentT));
            yield return null;
        }
        platform5MoveSound.Stop();
    }
}
