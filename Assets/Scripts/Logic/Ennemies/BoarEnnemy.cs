using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarEnnemy : Ennemy
{
    const int BASE_HP = 3;
    const float BASE_SPEED = 1.5f;
    const int BASE_MOVEMENT = 1;

    public BoarEnnemy() : base(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.BOAR)
    {

    }
}
