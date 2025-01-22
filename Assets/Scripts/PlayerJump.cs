using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower = 5f;
    private float gravity = 9.8f;

    private float airborneStartTime;
    //점프 시작시간
    private float airborneStartHeight;
    //처음 점프 높이
    private float airborneStartVelocity = 0;
    //최초 점프 속도
    
    private bool isGround = true;
    //땅에 닿았는지 확인
    private bool isJump = false;
    //점프 했는지 확인


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        //만약 Space키를 눌렀을 때
        {
            if (isGround)
            {
                isJump = false;
                airborneStartTime = Time.time;
                //Time.time은 게임 시작 후 현재까지 흐른 시간이다
                airborneStartHeight = transform.position.y;
                airborneStartVelocity = jumpPower;
            }
        }
        if (!isGround || isJump)
        {
            float t = Time.time - airborneStartTime;
            Vector3 newPosition = transform.position;
            float heightChange = airborneStartVelocity * t - gravity * t * t / 2;
            //공중에서 높이 변화를 계산하는 공식이다.
            
            newPosition.y = heightChange + airborneStartHeight;
            transform.position = newPosition;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    //Collider에 접촉했을 때
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            isGround = true;
            airborneStartVelocity = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    //Collider와 접촉이 끝날 때
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            airborneStartTime = Time.time;
        }
    }
}
