using UnityEngine;

public class BearTrap : TrapModel
{
    const int DAMAGE = 2;

    public ObjectCard CardPrefab;

    public BearTrap() : base ("Bear Trap", DAMAGE, TrapType.BEAR_TRAP)
    {
        
    }
}
