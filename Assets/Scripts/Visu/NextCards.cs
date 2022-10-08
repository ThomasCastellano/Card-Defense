using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCards : MonoBehaviour
{
    public const int SIZE_NEXT_CARDS = 2;

    public static NextCards instance;
    public List<CardBehaviour> lNextCards = new List<CardBehaviour>(new CardBehaviour[SIZE_NEXT_CARDS]);
    public bool needRefresh = false;

    public GameObject bearTrapCardPrefab;
    public GameObject netTrapCardPrefab;
    public GameObject spearCardPrefab;
    public GameObject torchCardPrefab;
    public GameObject mercenaryCardPrefab;
    public GameObject rexCardPrefab;
    public GameObject snowmanCardPrefab;
    public GameObject scarecrowCardPrefab;
    public GameObject restoreCardPrefab;

    // ----------------------------------------------
    // Awake
    // ----------------------------------------------
    void Awake()
    {
        instance = this;
        for (int i = 0; i < lNextCards.Count; i++)
        {
            lNextCards[i] = CreateNextCard();
        }
    }

    // ----------------------------------------------
    // AddNextCardToHand
    // ----------------------------------------------
    // Add a card to the specified index
    public GameObject OnDraw()
    {
        GameObject gameObject = lNextCards[0].gameObject;
        gameObject.GetComponent<CardBehaviour>().dragable = true;
        Destroy(lNextCards[0].gameObject);
        lNextCards[0] = lNextCards[1];
        lNextCards[1] = CreateNextCard();

        //Refresh();

        return gameObject;
    }

    // ----------------------------------------------
    // CreateNextCards
    // ----------------------------------------------
    public CardBehaviour CreateNextCard()
    {
        ItemModel item = null;

        // Random card type
        ItemType itemType = (ItemType)Random.Range(0, 4);

        // Cartes WEAPON
        if (itemType == ItemType.WEAPON)
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
        else if (itemType == ItemType.TRAP)
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
        else if (itemType == ItemType.ALLY)
        {
            AllyType type = (AllyType)Random.Range(0, 2);
            switch (type)
            {
                case AllyType.REX_DOG:
                    item = new RexDog();
                    break;
                case AllyType.MERCENARY:
                    item = new Mercenary();
                    break;
            }
        }
        else if (itemType == ItemType.DIVERSION)
        {
            DiversionType type = (DiversionType)Random.Range(0, 2);
            switch (type)
            {
                case DiversionType.SNOWMAN:
                    item = new Snowman();
                    break;
                case DiversionType.SCARECROW:
                    item = new Scarecrow();
                    break;
            }
        }
        else if (itemType == ItemType.SPECIAL)
        {
            SpecialType type = (SpecialType)Random.Range(0, 1);
            switch (type)
            {
                case SpecialType.RESTORE:
                    //item = new Restore();
                    break;
            }
        }

        CardBehaviour card = CreateCardFromModel(item);
        card.dragable = false;
        //card.itemModel = item;
        return card;
    }

    // ----------------------------------------------
    // Refresh
    // ----------------------------------------------
    public void Refresh()
    {
        // Supprime tous les childs
        //foreach (Transform child in transform)
        //{
        //    Destroy(child.gameObject);
        //}

        // Recrée les cartes
        //foreach (CardBehaviour card in lNextCards)
        //{
        //    if (card != null)
        //    {
        //        CardBehaviour card = CreateCardFromModel(itemModel);
        //        card.itemModel = itemModel;
        //    }
        //}
        for (int i = 0; i < lNextCards.Count; i++)
        {
            if (lNextCards[i] == null)
            {

            }
        }
    }

    // ----------------------------------------------
    // CreateCardFromModel
    // ----------------------------------------------
    public CardBehaviour CreateCardFromModel(ItemModel itemModel)
    {
        ItemType itemType = itemModel.itemType;
        GameObject gameObject = null;

        // Cartes WEAPON
        if (itemType == ItemType.WEAPON)
        {
            WeaponModel weaponCard = (WeaponModel)itemModel;
            switch (weaponCard.weaponType)
            {
                case WeaponType.SPEAR:
                    gameObject = Instantiate(spearCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
                case WeaponType.TORCH:
                    gameObject = Instantiate(torchCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
            }
        }
        // Cartes TRAP
        else if (itemType == ItemType.TRAP)
        {
            TrapModel trapCard = (TrapModel)itemModel;

            switch (trapCard.trapType)
            {
                case TrapType.BEAR_TRAP:
                    gameObject = Instantiate(bearTrapCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
                case TrapType.NET_TRAP:
                    gameObject = Instantiate(netTrapCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
            }
        }
        // Cartes ALLY
        else if (itemType == ItemType.ALLY)
        {
            AllyModel allyModel = (AllyModel)itemModel;

            switch (allyModel.allyType)
            {
                case AllyType.REX_DOG:
                    gameObject = Instantiate(rexCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
                case AllyType.MERCENARY:
                    gameObject = Instantiate(mercenaryCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
            }
        }
        // Cartes DIVERSION
        else if (itemType == ItemType.DIVERSION)
        {
            DiversionModel diversionModel = (DiversionModel)itemModel;

            switch (diversionModel.diversionType)
            {
                case DiversionType.SNOWMAN:
                    gameObject = Instantiate(snowmanCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
                case DiversionType.SCARECROW:
                    gameObject = Instantiate(scarecrowCardPrefab, transform);
                    gameObject.transform.localPosition = Vector3.zero;
                    break;
            }
        }

        CardBehaviour card = gameObject.GetComponent<CardBehaviour>();
        card.itemModel = itemModel;

        return card;
    }
}
