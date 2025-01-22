using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMover : MonoBehaviour
{
    private float currentAngle = 0f;
    private float movingSpeed = 3f;
    private float movingRadius = 2f;

    private void Update()
    {
        //1. 각도를 계산한다.
        currentAngle += movingSpeed * Time.deltaTime;
        
        //2. 각도에 따라 위치를 계산한다.
        var currentPosition = new Vector3(movingRadius * Mathf.Cos(currentAngle),
            movingRadius * Mathf.Sin(currentAngle), 0f);
        
        //3. 위치를 설정한다. 
        transform.localPosition = currentPosition;
    }
}
