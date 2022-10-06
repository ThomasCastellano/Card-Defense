using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public ItemModel itemModel;   // logic
    public GameObject boardObject;  // visu

    private BoardModel _boardModel;

    void Start()
    {
        _boardModel = BoardModel.instance;
        if (_boardModel == null)
        {
            Debug.LogError("No instance of BoardModel found");
        }
    }

    public ItemTile CreateTile(int row, int col)
    {
        itemModel.tile = new ItemTile(row, col, TileType.DIVERSION, itemModel, boardObject);
        return itemModel.tile;
    }
}
