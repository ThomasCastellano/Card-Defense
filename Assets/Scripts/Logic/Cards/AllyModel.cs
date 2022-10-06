public abstract class AllyModel : ItemModel
{
    public int damage;
    public AllyType allyType;

    protected AllyModel(int iDamage, AllyType iAllyType) : base(ItemType.ALLY)
    {
        damage = iDamage;
        allyType = iAllyType;
    }

    /*
    public override ItemTile CreateTile(int row, int col)
    {
        tile = new ItemTile(row, col, TileType.ALLY, this);
        return tile;
    }
    */

    public override void OnPlayed(int iRow, int iCol)
    {

    }
}
