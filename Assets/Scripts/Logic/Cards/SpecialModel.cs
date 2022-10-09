using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialModel : ItemModel
{
    public SpecialType specialType;

    public SpecialModel(SpecialType specialType) : base(ItemType.SPECIAL)
    {
        this.specialType = specialType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    //public abstract void Activate();
}
