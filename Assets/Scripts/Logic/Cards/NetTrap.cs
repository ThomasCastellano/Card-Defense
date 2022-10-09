public class NetTrap : TrapModel
{
    const int DAMAGE = 2;
    const float FREEZE_TIME = 1.0f;

    public NetTrap() : base(DAMAGE, TrapType.NET_TRAP)
    {

    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public override void Activate(Ennemy iEnnemy)
    {
        iEnnemy.FreezeMovement(FREEZE_TIME);
        this.tile.ToDestroyFlag = true;
        BoardModel.instance.needDestroy = true;
    }

}
