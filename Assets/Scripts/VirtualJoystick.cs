using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
//드래그를 사용하기 위해 각각 기능을 구현할 인터페이스를 추가해야 한다.
{
    private float maxMagnitude = 100f;

    public RectTransform handle;
    //RectTransform은 보통 UI작업에 사용되는데 Transform과 다른점은 앵커(Anchor)라는 기준점을 가진다.

    public void OnDrag(PointerEventData eventData)
    {
        handle.anchoredPosition += eventData.delta;
        //1. 드래그 입력이 들어온 만큼 움직인다.

        Vector2 currentPosition = handle.anchoredPosition;
        float currentMagnitude =
            Mathf.Sqrt(currentPosition.x * currentPosition.x + currentPosition.y * currentPosition.y);
        float currentAngleRadian = Mathf.Atan2(currentPosition.y, currentPosition.x);
        //2. 범위를 넘어간 경우, 최대 범위 내에서 움직인다.

        float clampedMagnitude = Mathf.Min(currentMagnitude, maxMagnitude);
        var clampedPosition = new Vector2(clampedMagnitude * Mathf.Cos(currentAngleRadian),
            clampedMagnitude * Mathf.Sin(currentAngleRadian));
        //최대길이의 벡터 생성

        handle.anchoredPosition = clampedPosition;
        //위치를 조절된 벡터로 설정
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector3.zero;
    }
}
