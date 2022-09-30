public class Tile
{
    public int _nRowPos;     // Position dans le tableau
    public int _nColPos;

    public bool _IsVisible;
    public bool _ToDestroyFlag = false;     // Indique si le GameObject lié à cette Tile doit être détruit

    public Tile(int iRow, int iCol, bool iVisible = true)
    {
        _nRowPos = iRow;
        _nColPos = iCol;
        _IsVisible = iVisible;
    }
}
