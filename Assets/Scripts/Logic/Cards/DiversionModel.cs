using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiversionModel : ItemModel
{
    public DiversionType diversionType;

    protected DiversionModel(string iName, DiversionType iDiversionType) : base(ItemType.DIVERSION)
    {
        diversionType = iDiversionType;
    }

    /*
    public override ItemTile CreateTile(int row, int col)
    {
        tile = new ItemTile(row, col, ItemToTile.DIVERSION, this, );
        return tile;
    }
    */

    public override void OnPlayed(int iRow, int iCol)
    {

    }
}
