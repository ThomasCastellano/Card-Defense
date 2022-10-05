using UnityEngine;

public abstract class ItemModel
{
    public string name;
    public CardType type;

    protected ItemModel(string iName, CardType iType)
    {
        name = iName;
        type = iType;
    }

    public abstract void OnPlayed(int iRow, int iCol);

}
