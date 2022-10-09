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
    // Les alliés ont autant de HP que de dégats
    // Si ils tuent un ennemi et qu'ils le restent
    // des dégats alors l'allié reste en jeu
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
