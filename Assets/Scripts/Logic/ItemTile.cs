using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTile : Tile
{
    public ItemModel itemModel;

    public ItemTile(int iRow, int iCol, TileType tileType, ItemModel itemModel, GameObject objectPrefab) : base(iRow, iCol, tileType, objectPrefab)
    {
        Row = iRow;
        Col = iCol;
        this.itemModel = itemModel;
    }

}
