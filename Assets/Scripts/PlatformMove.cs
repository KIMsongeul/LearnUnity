using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(-2,3,0);
    private Vector3 endPosition = new Vector3(2, 3, 0);

    private float duration = 2f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= duration)
        {
            //방향을 바꾼다.
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            
            //지난 시간을 수정한다.
            elapsedTime = elapsedTime - duration;
            startTime = Time.time;
            
        }
        //EaseInOutElastic으로 이동
        float t = elapsedTime / duration;
        float easedT = EaseInOutElastic(t);
        //easeT를 이용하여 위치를 설정한다.
        transform.position = Vector3.Lerp(startPosition, endPosition, easedT);

    }

    private float EaseInOutElastic(float x)
    {
        var c5 = (2 * Mathf.PI) / 4.5f;
        if (x == 0)
        {
            return 0;
        }

        if (x == 1)
        {
            return 1;
        }

        if (x < 0.5f)
        {
            return -((Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2);
        }

        return (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
    }
}
