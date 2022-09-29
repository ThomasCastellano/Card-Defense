public class Tile
{
    protected int _nRowPos;     // Position dans le tableau
    protected int _nColPos;

    public bool _IsVisible;

    public Tile(int iRow, int iCol, bool iVisible = true)
    {
        _nRowPos = iRow;
        _nColPos = iCol;
        _IsVisible = iVisible;
    }
}
