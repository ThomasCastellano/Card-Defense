using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearEnnemy : Ennemy
{
    const int BASE_HP = 6;
    const float BASE_SPEED = 3.0f;
    const int BASE_MOVEMENT = 2;

    public void Start()
    {
        Init(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.BEAR);
    }

    //public BearEnnemy() : base(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.BEAR)
    //{

    //}
}
