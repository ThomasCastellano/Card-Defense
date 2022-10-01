using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster 
{
    public int spawnTime;
    public MonsterType monsterType;
}

public enum MonsterType
{
    Monster1,
    Monster2
}
