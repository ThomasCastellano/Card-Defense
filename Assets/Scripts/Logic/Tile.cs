using UnityEngine;

public class Tile
{
    public int Row;     // Position dans le tableau
    public int Col;
    public bool ToDestroyFlag = false;     // Indique si le GameObject li� � cette Tile doit �tre d�truit
    public TileType tileType;

    public GameObject objectPrefab;

    public Tile(int iRow, int iCol, TileType tileType = TileType.EMPTY, GameObject objectPrefab = null)
    {
        Row = iRow;
        Col = iCol;
        this.tileType = tileType;
        this.objectPrefab = objectPrefab;
    }
}
