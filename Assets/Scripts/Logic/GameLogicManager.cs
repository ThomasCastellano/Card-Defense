using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    private BoardModel _boardModel;
    private PlayerHandModel _playerHandModel;

    // Start is called before the first frame update
    void Start()
    {
        _boardModel = new BoardModel();
        _playerHandModel = new PlayerHandModel();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoardModel.needDestroy)
        {
            _boardModel.DestroyFlaggedTiles();
        }

        _boardModel.MoveEnnemies();
        _boardModel.AddEnnemy();

        if (BoardModel._NeedRefresh)
        {
            _boardModel.RefreshDisplay();
        }
    }

    [ContextMenu("PlayTrapCard")]
    void PlayTrapCard()
    {
        BearTrapCard card = new BearTrapCard();
        _boardModel.AddTrapFromCard(card, Random.Range(0, 7), Random.Range(0, 3));
    }

    [ContextMenu("Refresh")]
    void RefreshDisplay()
    {
        _boardModel.RefreshDisplay();
    }
}
