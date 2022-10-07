using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private GameManager _gameManager;
    private BoardModel _boardModel;
    private TileContainer _tileContainer;

    public void Start()
    {
        _gameManager = GameManager.instance;
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

            // Si la carte est une arme, on ne peut la jouer que sur une tile contenant un ennemi
            if (card.itemModel.itemType == ItemType.WEAPON)
            {
                if (_boardModel.GetTile(_tileContainer.Row, _tileContainer.Col).tileType != TileType.ENNEMY)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = card.originalPosition;
                    card.transform.position = card.originalPosition;
                    return;
                }
            }

            _gameManager.PlayCard(card, _tileContainer.Row, _tileContainer.Col);
        }
    }
}
