public enum TileType
{
    EMPTY,
    ENNEMY,
    TRAP,
    ALLY,
    DIVERSION
}

public enum ItemType
{
    WEAPON,
    TRAP,
    ALLY,
    DIVERSION,
    SPECIAL,
}

public enum ItemToTile
{
    WEAPON = TileType.EMPTY,
    TRAP = TileType.TRAP,
    ALLY = TileType.ALLY,
    DIVERSION = TileType.DIVERSION,
    SPECIAL = TileType.EMPTY,
}

public enum WeaponType
{
    SPEAR,
    TORCH
}

public enum TrapType
{
    BEAR_TRAP,
    NET_TRAP,
}

public enum AllyType
{
    MERCENARY,
    REX_DOG
}

public enum DiversionType
{
    SNOWMAN,
    SCARECROW
}

public enum SpecialType
{
    RESTORE
}

public enum EnnemyType
{
    BEAR,
    GNOME,
}
