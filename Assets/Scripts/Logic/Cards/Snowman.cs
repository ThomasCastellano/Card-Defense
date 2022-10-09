public class Snowman : DiversionModel
{
    const float FREEZE_TIME = 2f;

    public Snowman() : base("Snowman", DiversionType.SNOWMAN)
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
