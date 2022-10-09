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
}
