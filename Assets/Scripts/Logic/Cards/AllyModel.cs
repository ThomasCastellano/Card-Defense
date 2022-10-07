public abstract class AllyModel : ItemModel
{
    public int damage;
    public AllyType allyType;

    protected AllyModel(int iDamage, AllyType iAllyType) : base(ItemType.ALLY)
    {
        damage = iDamage;
        allyType = iAllyType;
    }
}
