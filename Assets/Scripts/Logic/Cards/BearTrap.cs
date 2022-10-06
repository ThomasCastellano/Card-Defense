using UnityEngine;

public class BearTrap : TrapModel
{
    const int DAMAGE = 2;

    public BearTrap() : base (DAMAGE, TrapType.BEAR_TRAP)
    {
        
    }
}
