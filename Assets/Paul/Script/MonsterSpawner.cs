using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterSpawner : MonoBehaviour 
{
    public List<GameObject> monstersPrefabs;
    public List<Monster> monsters;


    private void Update()
    {
        foreach (Monster monster in monsters)
        {
            if ( monster.isSpawned == false && monster.spawnTime > Time.time)
            {
                Instantiate(monstersPrefabs[(int)monster.monsterType], transform.GetChild(monster.Spawner).transform);
                monster.isSpawned = true;
            }
        }
    }
}

