using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeEnnemy : Ennemy
{
    const int BASE_HP = 2;
    const float BASE_SPEED = 2;
    const int BASE_MOVEMENT = 1;

    public void Start()
    {
        Init(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.GNOME);
    }

    //public GnomeEnnemy() : base(BASE_HP, BASE_SPEED, BASE_MOVEMENT, EnnemyType.GNOME)
    //{

    //}
}
