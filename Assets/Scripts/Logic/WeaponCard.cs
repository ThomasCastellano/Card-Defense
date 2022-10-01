using UnityEngine;

public abstract class WeaponCard : Card
{
    public int damage;
    public WeaponType weaponType;

    protected WeaponCard(string iName, int iDamage, WeaponType iWeaponType) : base(iName, CardType.WEAPON)
    {
        damage = iDamage;
        weaponType = iWeaponType;
    }

    public override void OnPlayed(int iRow, int iCol)
    {

    }
}
