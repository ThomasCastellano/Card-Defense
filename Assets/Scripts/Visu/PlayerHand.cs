using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public const int SIZE_HAND = 4;

#nullable enable
    public List<CardBehaviour?> lPlayerHand = new List<CardBehaviour?>(new CardBehaviour?[SIZE_HAND]);
#nullable disable

    public GameObject bearTrapCardPrefab;
    public GameObject netTrapCardPrefab;
    public GameObject spearCardPrefab;
    public GameObject torchCardPrefab;
    public GameObject mercenaryCardPrefab;
    public GameObject rexCardPrefab;
    public GameObject snowmanCardPrefab;
    public GameObject scarecrowCardPrefab;
    public GameObject restoreCardPrefab;

    //private PlayerHandModel _PlayerHandModel;
    [SerializeField] private NextCards _NextCards;


    // ----------------------------------------------
    // Start
    // ----------------------------------------------
    void Start()
    {
        //_PlayerHandModel = PlayerHandModel.instance;
        //_NextCards = NextCards.instance;
        //InitPlayerHand();

        for (int i = 0; i < SIZE_HAND; i++)
        {
            DrawCard(i);
        }
        Refresh();
    }

    // ----------------------------------------------
    // DrawCard
    // ----------------------------------------------
    public void DrawCard(int index)
    {
        if (index < lPlayerHand.Count)
        {
            //lPlayerHand[index] = _NextCards.lNextCards[0];
            //_NextCards.OnDraw();
            GameObject gameObject = _NextCards.OnDraw();
            lPlayerHand[index] = gameObject.GetComponent<CardBehaviour>();
        }
    }

    // ----------------------------------------------
    // Refresh
    // ----------------------------------------------
    public void Refresh()
    {
        // Supprime tous les childs
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Recrée les cartes
        //foreach (CardBehaviour card in lPlayerHand)
        //{
        //    card.gameObject.transform.parent = this.transform;
        //}

        for (int i = 0; i < lPlayerHand.Count; i++)
        {
            ItemModel itemModel = lPlayerHand[i].itemModel;
            if (itemModel != null)
            {
                CardBehaviour card = CreateCardFromModel(itemModel);
                lPlayerHand[i] = card;
                card.gameObject.transform.SetParent(this.transform);
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

    // ----------------------------------------------
    // OnCardPlayed
    // ----------------------------------------------
    // When a card is played from UI this method is called
    public void OnCardPlayed(CardBehaviour card)
    {
        int index = lPlayerHand.IndexOf(card);
        lPlayerHand[index] = null;  // Pas de remove pour garder une taille de SIZE_HAND

        Destroy(card.gameObject);

        DrawCard(index);
        Refresh();

        //int index = lPlayerHand.IndexOf(cardItemModel);
        //Debug.Log(cardItemModel.GetHashCode());
        //foreach (ItemModel i in lPlayerHand)
        //{
        //    Debug.Log(i.GetHashCode());
        //}
        //Debug.Log(lPlayerHand.IndexOf(cardItemModel));
        //Debug.Log(lPlayerHand.Contains(cardItemModel));
        //for (int i = 0; i < lPlayerHand.Count; i++)
        //{
        //    if (lPlayerHand[i].GetHashCode() == cardItemModel.GetHashCode())
        //    {
        //        index = i;
        //    }
        //}
        //if (index > -1)
        //{
        //lPlayerHand.Remove(cardItemModel);
        //AddNextCardToHand(index);
        //}
    }
}
