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

    public abstract void Activate(Ennemy iEnnemy);
}
