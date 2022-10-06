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

    public override void OnPlayed(int iRow, int iCol)
    {

    }
}
