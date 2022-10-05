using UnityEngine;

public abstract class WeaponModel : ItemModel
{
    public int damage;
    public WeaponType weaponType;

    protected WeaponModel(string iName, int iDamage, WeaponType iWeaponType) : base(iName, CardType.WEAPON)
    {
        damage = iDamage;
        weaponType = iWeaponType;
    }

    public override void OnPlayed(int iRow, int iCol)
    {

    }
}
