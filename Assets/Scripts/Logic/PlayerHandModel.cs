using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandModel
{
    const int SIZE_HAND = 4;

    public static List<Card> _lPlayerHand = new List<Card>();        // Main du joueur

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public PlayerHandModel()
    {
        BuildHand();
    }

    // ----------------------------------------------
    // BuildHand
    // ----------------------------------------------
    public void BuildHand()
    {
        for (int i = 0; i < SIZE_HAND; i++)
        {
            _lPlayerHand.Add(CreateRandomCard());
        }
    }

    // ----------------------------------------------
    // CreateRandomCard
    // ----------------------------------------------
    public Card CreateRandomCard()
    {
        Card card = null;

        // Random card type
        CardType cardType = (CardType)Random.Range(0, 2);

        if (cardType == CardType.WEAPON)
        {
            WeaponType type = (WeaponType)Random.Range(0, 2);
            switch (type)
            {
                case WeaponType.HUNTING_RIFLE:
                    card = new HuntingRifleCard();
                    break;
                case WeaponType.KNIFE:
                    card = new Knife();
                    break;
            }
        }
        else if (cardType == CardType.TRAP)
        {
            TrapType type = (TrapType)Random.Range(0, 2);
            switch (type)
            {
                case TrapType.BEAR_TRAP:
                    card = new BearTrapCard();
                    break;
                case TrapType.LEAVES_TRAP:
                    card = new LeavesTrapCard();
                    break;
            }
        }

        return card;
    }
}
