using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapModel : ItemModel
{
    public int damage;
    public TrapType trapType;

    protected TrapModel(int iDamage, TrapType iTrapType) : base(ItemType.TRAP)
    {
        damage = iDamage;
        trapType = iTrapType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public void Activate(Ennemy iEnnemy)
    {
        iEnnemy.Hp -= damage;
        if (iEnnemy.Hp <= 0)
        {
            iEnnemy.tile.ToDestroyFlag = true;
        }
        this.tile.ToDestroyFlag = true;
        BoardModel.instance.needDestroy = true;
    }
}
