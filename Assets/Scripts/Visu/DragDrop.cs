using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private CardBehaviour _cardBehaviour;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _cardBehaviour = GetComponent<CardBehaviour>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (_cardBehaviour.dragable)
        {
            _rectTransform.localScale *= 0.5f;
            _rectTransform.position = Input.mousePosition;
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (_cardBehaviour.dragable)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (_cardBehaviour.dragable)
        {
            _canvasGroup.alpha = 1f;
            _rectTransform.localScale *= 2f;
            _canvasGroup.blocksRaycasts = true;
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
