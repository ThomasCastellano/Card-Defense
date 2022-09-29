
public class Trap : Tile
{
    int _nDamage = 0;
    // TODO : ajouter une zone d'effet avec un tableau 2D
    public Trap(int iRow, int iCol, int iDamage, bool iVisible = true) : base(iRow, iCol, iVisible)
    {
        _nDamage = iDamage;
    }
}
