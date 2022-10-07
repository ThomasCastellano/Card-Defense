using UnityEngine;

public abstract class WeaponModel : ItemModel
{
    public int damage;
    public WeaponType weaponType;

    protected WeaponModel(int iDamage, WeaponType iWeaponType) : base(ItemType.WEAPON)
    {
        damage = iDamage;
        weaponType = iWeaponType;
    }

    // ----------------------------------------------
    // Activate
    // ----------------------------------------------
    public void Activate(Ennemy iEnnemy)
    {
        iEnnemy.Hp -= damage;
        if (iEnnemy.Hp <= 0)
        {
            iEnnemy.tile.ToDestroyFlag = true;
        }
        //this.tile.ToDestroyFlag = true;
        BoardModel.instance.needDestroy = true;
    }
}
