public abstract class AllyModel : ItemModel
{
    public int damage;
    public AllyType allyType;

    protected AllyModel(int damage, AllyType allyType) : base(ItemType.ALLY)
    {
        this.damage = damage;
        this.allyType = allyType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    // Les alli�s ont autant de HP que de d�gats
    // Si ils tuent un ennemi et qu'ils le restent
    // des d�gats alors l'alli� reste en jeu
    public void Activate(Ennemy iEnnemy)
    {
        int newDamage = damage - iEnnemy.Hp;
        iEnnemy.Hp -= damage;
        if (iEnnemy.Hp <= 0)
        {
            iEnnemy.tile.ToDestroyFlag = true;
            BoardModel.instance.needDestroy = true;
        }
        if (newDamage <= 0)
        {
            this.tile.ToDestroyFlag = true;
            BoardModel.instance.needDestroy = true;
        }
        else
        {
            damage = newDamage;
        }
    }

}
