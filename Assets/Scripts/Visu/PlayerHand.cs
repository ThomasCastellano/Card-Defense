using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public const int SIZE_HAND = 4;

    public static PlayerHand instance;

#nullable enable
    public List<CardBehaviour?> lPlayerHand = new List<CardBehaviour?>(new CardBehaviour?[SIZE_HAND]);
#nullable disable
    // Liste permettant de vérifier si un emplacement de carte est bloqué
    // après qu'un ennemie a atteint le joueur
    public List<bool> lIsCardPlayable = new List<bool>(new bool[SIZE_HAND]);

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
    // Awake
    // ----------------------------------------------
    private void Awake()
    {
        instance = this;
    }

    // ----------------------------------------------
    // Start
    // ----------------------------------------------
    void Start()
    {
        for (int i = 0; i < SIZE_HAND; i++)
        {
            DrawCard(i);
            lIsCardPlayable[i] = true;
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
            GameObject gameObject = _NextCards.OnDraw();
            lPlayerHand[index] = gameObject.GetComponent<CardBehaviour>();
        }
    }

    // ----------------------------------------------
    // Refresh
    // ----------------------------------------------
    public void Refresh()
    {
        // Supprime tous les childs (cartes)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Recrée les cartes
        for (int i = 0; i < SIZE_HAND; i++)
        {
            ItemModel itemModel = lPlayerHand[i].itemModel;
            if (itemModel != null)
            {
                CardBehaviour card = CreateCardFromModel(itemModel);
                lPlayerHand[i] = card;
                card.gameObject.transform.SetParent(this.transform);
                if (lIsCardPlayable[i] == false)
                {
                    card.dragable = false;
                    card.GetComponent<Image>().color = Color.gray;
                }
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
        lPlayerHand[index] = null;  // Pas de remove pour garder une taille fixe de SIZE_HAND

        Destroy(card.gameObject);

        DrawCard(index);
        Refresh();
    }
}
