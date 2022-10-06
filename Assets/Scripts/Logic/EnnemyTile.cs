using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTile : Tile
{
    public Ennemy ennemyModel;

    public EnnemyTile(int iRow, int iCol, TileType tileType, Ennemy ennemyModel, GameObject objectPrefab) : base(iRow, iCol, tileType, objectPrefab)
    {
        Row = iRow;
        Col = iCol;
        this.ennemyModel = ennemyModel;
    }
}
