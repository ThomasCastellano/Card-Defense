using UnityEngine;

public abstract class Card
{
    public string name;
    public CardType type;

    protected Card(string iName, CardType iType)
    {
        name = iName;
        type = iType;
    }

    public abstract void OnPlayed(int iRow, int iCol);

}
