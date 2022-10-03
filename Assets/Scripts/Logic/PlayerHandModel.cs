using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandModel
{
    const int SIZE_HAND = 4;
    const int SIZE_NEXT_CARDS = 2;

    public static List<Card> _lPlayerHand = new List<Card>(SIZE_HAND);        // Main du joueur
    public static List<Card> _lNextCards = new List<Card>(SIZE_NEXT_CARDS);       // Deux prochaines cartes

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
            _lPlayerHand[i] = CreateRandomCard();
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

    public void AddNextCardToHand(int index)
    {
        _lPlayerHand[index] = _lNextCards[0];
        _lNextCards[0] = _lNextCards[1];
        _lNextCards[1] = CreateRandomCard();
    }

    // ----------------------------------------------
    // OnCardPlayed
    // ----------------------------------------------
    // When a card is played from UI this method is called
    public void OnCardPlayed(Card card, int index)
    {

    }

}
