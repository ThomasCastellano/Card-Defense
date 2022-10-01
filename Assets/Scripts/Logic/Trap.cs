public class Trap : Tile
{
    public TrapType trapType;

    private int _nDamage = 0;
    // TODO : ajouter une zone d'effet avec un tableau 2D

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Trap(int iRow, int iCol, int iDamage, TrapType iTrapType, bool iVisible = true) : base(iRow, iCol, iVisible)
    {
        _nDamage = iDamage;
        trapType = iTrapType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public void Activate(Ennemy iEnnemy)
    {
        iEnnemy._nHp -= _nDamage;
        if (iEnnemy._nHp <= 0)
        {
            iEnnemy._ToDestroyFlag = true;
        }
        this._ToDestroyFlag = true;
        BoardModel.needDestroy = true;
    }
}
