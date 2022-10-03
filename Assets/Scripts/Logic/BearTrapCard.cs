using UnityEngine;

public class BearTrapCard : TrapCard
{
    const int DAMAGE = 4;

    public ObjectCard CardPrefab;

    public BearTrapCard() : base ("Bear Trap", DAMAGE, TrapType.BEAR_TRAP)
    {
        
    }
}
