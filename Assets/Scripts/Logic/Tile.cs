public class Tile
{
    public int Row;     // Position dans le tableau
    public int Col;

    public bool IsVisible;
    public bool ToDestroyFlag = false;     // Indique si le GameObject li� � cette Tile doit �tre d�truit

    public Tile(int iRow, int iCol, bool iVisible = true)
    {
        Row = iRow;
        Col = iCol;
        IsVisible = iVisible;
    }
}
