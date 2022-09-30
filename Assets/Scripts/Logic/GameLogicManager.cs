using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    private BoardModel _boardModel;

    // Start is called before the first frame update
    void Start()
    {
        _boardModel = new BoardModel();
    }

    // Update is called once per frame
    void Update()
    {
        _boardModel.MoveEnnemies();
        _boardModel.AddEnnemy();
        if (BoardModel._NeedRefresh)
        {
            _boardModel.RefreshDisplay();
            BoardModel._NeedRefresh = false;
        }
    }

    [ContextMenu("Refresh")]
    void RefreshDisplay()
    {
        _boardModel.RefreshDisplay();
    }
}
