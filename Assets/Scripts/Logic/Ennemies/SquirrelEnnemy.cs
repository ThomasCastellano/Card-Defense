using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelEnnemy : Ennemy
{
    const int BASE_HP = 1;
    const float BASE_SPEED = 1.1f;
    const int BASE_MOVEMENT = 1;

    public SquirrelEnnemy() : base(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.SQUIRREL)
    {

    }
}
