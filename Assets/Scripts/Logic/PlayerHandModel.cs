using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandModel
{
    public static PlayerHandModel instance;

    public List<ItemModel> lPlayerHand = new List<ItemModel>(new ItemModel[SIZE_HAND]);        // Main du joueur
    public List<ItemModel> lNextCards = new List<ItemModel>(new ItemModel[SIZE_NEXT_CARDS]);       // Deux prochaines cartes

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
    public ItemModel CreateRandomCard()
    {
        ItemModel item = null;

        // Random card type
        ItemType cardType = (ItemType)Random.Range(0, 2);

        if (cardType == ItemType.WEAPON)
        {
            WeaponType type = (WeaponType)Random.Range(0, 2);
            switch (type)
            {
                case WeaponType.SPEAR:
                    item = new Spear();
                    break;
                case WeaponType.TORCH:
                    item = new Torch();
                    break;
            }
        }
        else if (cardType == ItemType.TRAP)
        {
            TrapType type = (TrapType)Random.Range(0, 2);
            switch (type)
            {
                case TrapType.BEAR_TRAP:
                    item = new BearTrap();
                    break;
                case TrapType.NET_TRAP:
                    item = new NetTrap();
                    break;
            }
        }

        return item;
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
    public void OnCardPlayed(ItemModel card, int index)
    {

    }

}
