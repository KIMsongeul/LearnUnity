using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private float minimumX = -2f;
    private float maximumX = 2f;
    private float speed = 3f;

    private void Update()
    {
        //1. 현재 위치를 가져온다.
        Vector3 currentPosition = transform.position;
        
        //2. x축으로 이동할 양을 계산한다.
        float movingAmount = speed * Time.deltaTime;
        
        //3. 이동할 양을 현재 위치에 더한다.
        currentPosition.x += movingAmount;
        
        //4. 최대값, 최소값을 넘어간 경우 최대값, 최소값으로 설정한다.
        if (currentPosition.x < minimumX)
        {
            currentPosition.x = minimumX;
            //-1를 곱해주면 양수는 음수, 음수는 양수로 바뀌니까 반대로 움직인다.
            speed *= -1f;
        }
        else if (currentPosition.x > maximumX)
        {
            currentPosition.x = maximumX;
            speed *= -1f;
        }
        
        //5. 위치를 설정한다.
        transform.position = currentPosition;
    }
}
