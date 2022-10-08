using UnityEngine;

public class BearTrap : TrapModel
{
    const int DAMAGE = 2;

    public BearTrap() : base (DAMAGE, TrapType.BEAR_TRAP)
    {
        
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public override void Activate(Ennemy iEnnemy)
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
