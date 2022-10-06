using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private BoardModel _boardModel;
    private TileContainer _tileContainer;

    public void Start()
    {
        _boardModel = BoardModel.instance;
        _tileContainer = GetComponent<TileContainer>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            CardBehaviour card = eventData.pointerDrag.GetComponent<CardBehaviour>();
            _boardModel.PlayCard(card, _tileContainer.Row, _tileContainer.Col);
        }
    }
}
