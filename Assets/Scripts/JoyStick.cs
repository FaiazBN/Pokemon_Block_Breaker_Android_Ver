using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    [SerializeField] public GameObject joyStick;
    [SerializeField] public GameObject joyStickBG;
    [SerializeField] public Vector2 joyStickVec;
    private Vector2 joyStickTouchPos;
    private Vector2 joyStickOriginalPos;
    private float joyStickRadius;

    private void Start()
    {
        joyStickOriginalPos = joyStickBG.transform.position;
        joyStickRadius = joyStickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    public void PointerDown()
    {
        joyStick.transform.position = Input.mousePosition;
        joyStickBG.transform.position = Input.mousePosition;
        joyStickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joyStickVec = (dragPos - joyStickTouchPos).normalized;

        float joyStickDist = Vector2.Distance(dragPos, joyStickTouchPos);

        if (joyStickDist < joyStickRadius)
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickDist;
        }

        else
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickRadius;
        }


    }
    public void PointerUp()
    {
        joyStickVec = Vector2.zero;
        joyStick.transform.position = joyStickOriginalPos;
        joyStickBG.transform.position = joyStickOriginalPos;
    }

}
