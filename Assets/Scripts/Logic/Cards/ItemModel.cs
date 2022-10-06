using UnityEngine;

public abstract class ItemModel
{
    //public bool ToDestroyFlag = false;
    public ItemType itemType;

    public ItemTile tile;

    protected ItemModel(ItemType iType)
    {
        itemType = iType;
    }

    //public abstract ItemTile CreateTile(int row, int col);

    public abstract void OnPlayed(int iRow, int iCol);

}
