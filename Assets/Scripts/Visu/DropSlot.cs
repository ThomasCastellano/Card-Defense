using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private GameManager _gameManager;
    private BoardModel _boardModel;
    private TileContainer _tileContainer;
    private GridLayoutGroup _grid;

    public void Start()
    {
        _gameManager = GameManager.instance;
        _boardModel = BoardModel.instance;
        _tileContainer = GetComponent<TileContainer>();
        _grid = _gameManager.playerHand.GetComponent<GridLayoutGroup>();
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
                    //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = card.originalPosition;
                    //card.transform.position = card.originalPosition;
                    //card.transform.SetParent(_grid.transform);
                    //card.transform.localPosition = Vector3.zero;
                    //_gameManager.playerHand.Refresh();
                    _gameManager.playerHand.gameObject.SetActive(false);
                    _gameManager.playerHand.gameObject.SetActive(true);
                    return;
                }
            }
            // Les autres cartes ne peuvent pas être joués sur une case contenant un ennemi ou précédente carte
            else
            {
                if (_boardModel.GetTile(_tileContainer.Row, _tileContainer.Col).tileType != TileType.EMPTY)
                {
                    //card.transform.SetParent(_grid.transform);
                    //card.transform.localPosition = Vector3.zero;
                    //_gameManager.playerHand.Refresh();
                    _gameManager.playerHand.gameObject.SetActive(false);
                    _gameManager.playerHand.gameObject.SetActive(true);
                    return;
                }
            }

            _gameManager.PlayCard(card, _tileContainer.Row, _tileContainer.Col);
        }
    }
}
