using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectAutoFit : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    //public int ShowCount;
    //public int AllCount;
    /// <summary>
    /// 开始到结束拖动的次数
    /// </summary>
    public int StepsOfStart2End;
    float StepValue;

    ScrollRect scrollRect;
    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartX = eventData.position.x;
        StepValue = 1f / (float)(StepsOfStart2End);
    }
    float steps;
    float StartX;
    public void OnEndDrag(PointerEventData eventData)
    {
        float offset = 0;
        offset = eventData.position.x - StartX;
        if (Mathf.Abs(offset) > 50)
        {
            if (offset < 0)
            {
                steps = Mathf.CeilToInt(scrollRect.horizontalScrollbar.value / StepValue);

            }
            else
            {
                steps = Mathf.FloorToInt(scrollRect.horizontalScrollbar.value / StepValue);
            }
        }
        SessionsMove(StepValue * (steps));

    }

    void OnDragEnd()
    {

    }
    public void SessionsMove(float value)
    {
        DOTween.To(() => scrollRect.horizontalScrollbar.value, v => scrollRect.horizontalScrollbar.value = v, value, 0.5f).SetEase(Ease.InOutQuad);
    }
}
