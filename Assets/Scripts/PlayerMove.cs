using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4.0f;

    private float inputH;

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        //Horizontal은 키보드의 방향키나, 조이스틱의 좌우 등 횡이동의 값을 받아온다.

        if (inputH < 0 || inputH > 0)
        //Horizontal의 입력값은 좌 -1, 우 1이다. 
        {
            float movementDistance = inputH * speed * Time.deltaTime;
            //Time.deltaTime은 유니티 기능으로 직전의 프레임으로부터 흐른 시간(초)를 뜻한다.
            //void Update는 프레임마다 호출되는데 이러면 컴퓨터의 성능에 따라 이동속도가 달라지기때문에 Time.deltaTime을 곱해서 문제를 해결한다.
            transform.position += new Vector3(movementDistance, 0, 0);
        }
    }
}
