using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearEnnemy : Ennemy
{
    const int BASE_HP = 6;
    const int BASE_SPEED = 3;
    const int BASE_MOVEMENT = 2;
    public BearEnnemy() : base(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.BEAR)
    {

    }
}
