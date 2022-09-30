
public class Trap : Tile
{
    private int _nDamage = 0;
    // TODO : ajouter une zone d'effet avec un tableau 2D

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Trap(int iRow, int iCol, int iDamage, bool iVisible = true) : base(iRow, iCol, iVisible)
    {
        _nDamage = iDamage;
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
    }
}
