using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapModel : ItemModel
{
    public int damage;
    public TrapType trapType;

    protected TrapModel(string iName, int iDamage, TrapType iTrapType) : base(iName, CardType.TRAP)
    {
        damage = iDamage;
        trapType = iTrapType;
    }

    public override void OnPlayed(int iRow, int iCol)
    {
        
    }
}
