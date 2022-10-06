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

    /*
    public override ItemTile CreateTile(int row, int col)
    {
        tile = new ItemTile(row, col, TileType.TRAP, this);
        return tile;
    }
    */

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
        BoardModel.needDestroy = true;
    }

    public override void OnPlayed(int iRow, int iCol)
    {
        
    }
}
