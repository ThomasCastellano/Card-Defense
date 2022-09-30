using UnityEngine;

public abstract class Card
{
    public string _sName;
    public int _Type;
    public int _nDamage;

    public abstract void OnPlayed(int iRow, int iCol);

}
