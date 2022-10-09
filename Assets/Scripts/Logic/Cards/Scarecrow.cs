public class Scarecrow : DiversionModel
{
    const float FREEZE_TIME = 2f;

    public Scarecrow() : base("Scarecrow", DiversionType.SCARECROW)
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
