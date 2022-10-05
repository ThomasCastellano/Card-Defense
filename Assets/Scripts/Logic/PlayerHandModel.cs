using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandModel
{
    public static PlayerHandModel instance;

    public List<Card> lPlayerHand = new List<Card>(new Card[SIZE_HAND]);        // Main du joueur
    public List<Card> lNextCards = new List<Card>(new Card[SIZE_NEXT_CARDS]);       // Deux prochaines cartes

    public const int SIZE_HAND = 4;
    public const int SIZE_NEXT_CARDS = 2;

    public bool needRefresh = false;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public PlayerHandModel()
    {
        instance = this;
        BuildHand();
        BuildNextCards();
    }

    // ----------------------------------------------
    // BuildHand
    // ----------------------------------------------
    public void BuildHand()
    {
        for (int i = 0; i < SIZE_HAND; i++)
        {
            lPlayerHand[i] = CreateRandomCard();
        }
        needRefresh = true;
    }

    // ----------------------------------------------
    // BuildNextCards
    // ----------------------------------------------
    public void BuildNextCards()
    {
        for (int i = 0; i < SIZE_NEXT_CARDS; i++)
        {
            lNextCards[i] = CreateRandomCard();
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
        lPlayerHand[index] = lNextCards[0];
        lNextCards[0] = lNextCards[1];
        lNextCards[1] = CreateRandomCard();
        needRefresh = true;
    }

    // ----------------------------------------------
    // OnCardPlayed
    // ----------------------------------------------
    // When a card is played from UI this method is called
    public void OnCardPlayed(Card card, int index)
    {

    }

}
