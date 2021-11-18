using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastle4 : MonoBehaviour
{
    public Vector3 start = Vector3.zero;
    public Vector3 end = Vector3.zero;
    public float duration = 8;

    public TransportationArea3Controller transportationarea3;

    float currentT = 0;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        currentT = 0;
        transform.position = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (transportationarea3.cnt3 == true)
        {
            if (transform.position != end)
            {
                currentT += Time.deltaTime / duration;
                currentT = Mathf.Clamp01(currentT);
                transform.position = Vector3.Lerp(start, end, curve.Evaluate(currentT));
		Debug.Log("MOVE");;
            }
        }
    }
}