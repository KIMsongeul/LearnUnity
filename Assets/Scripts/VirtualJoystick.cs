using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//드래그를 사용하기 위해 각각 기능을 구현할 인터페이스를 추가해야 한다.
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그를 시작합니다.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("핸들이 범위를 벗어나지 않게 제어해줍니다.");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("핸들을 초기화합니다.");
    }
}
