public class Trap : Tile
{
    public TrapType trapType;

    private int Damage = 0;
    // TODO : ajouter une zone d'effet avec un tableau 2D

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Trap(int iRow, int iCol, int iDamage, TrapType iTrapType, bool iVisible = true) : base(iRow, iCol, iVisible)
    {
        Damage = iDamage;
        trapType = iTrapType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public void Activate(Ennemy iEnnemy)
    {
        iEnnemy.Hp -= Damage;
        if (iEnnemy.Hp <= 0)
        {
            iEnnemy.ToDestroyFlag = true;
        }
        this.ToDestroyFlag = true;
        BoardModel.needDestroy = true;
    }
}
