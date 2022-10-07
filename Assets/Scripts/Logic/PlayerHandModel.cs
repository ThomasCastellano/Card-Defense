//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerHandModel
//{
//    public const int SIZE_HAND = 4;

//    public static PlayerHandModel instance;
//    public List<CardBehaviour> lPlayerHand = new List<CardBehaviour>(new CardBehaviour[SIZE_HAND]);        // Main du joueur
//    public bool needRefresh = false;

//    private NextCards _nextCards = NextCards.instance;

//    // ----------------------------------------------
//    // Constructor
//    // ----------------------------------------------
//    public PlayerHandModel()
//    {
//        instance = this;

//        for (int i = 0; i < SIZE_HAND; i++)
//        {
//            DrawCard(i);
//        }

//        //needRefresh = true;
//    }

//    // ----------------------------------------------
//    // DrawCard
//    // ----------------------------------------------
//    public void DrawCard(int index)
//    {
//        if (index < lPlayerHand.Count)
//        {
//            lPlayerHand[index] = _nextCards.lNextCards[0];
//            _nextCards.Refresh();
//        }
//    }

//    // ----------------------------------------------
//    // BuildHand
//    // ----------------------------------------------
//    public void BuildHand()
//    {
//        for (int i = 0; i < SIZE_HAND; i++)
//        {
//            //lPlayerHand[i] = CreateRandomCard();
//        }
//        needRefresh = true;
//    }


//    // ----------------------------------------------
//    // OnCardPlayed
//    // ----------------------------------------------
//    // When a card is played from UI this method is called
//    public void OnCardPlayed(ItemModel cardItemModel)
//    {
//        //lPlayerHand.Remove(cardItemModel);
//        //int index = -1;
//        int index = lPlayerHand.IndexOf(cardItemModel);
//        Debug.Log(cardItemModel.GetHashCode());
//        foreach (ItemModel i in lPlayerHand)
//        {
//            Debug.Log(i.GetHashCode());
//        }
//        Debug.Log(lPlayerHand.IndexOf(cardItemModel));
//        Debug.Log(lPlayerHand.Contains(cardItemModel));
//        //for (int i = 0; i < lPlayerHand.Count; i++)
//        //{
//        //    if (lPlayerHand[i].GetHashCode() == cardItemModel.GetHashCode())
//        //    {
//        //        index = i;
//        //    }
//        //}
//        if (index > -1)
//        {
//            lPlayerHand.Remove(cardItemModel);
//            //AddNextCardToHand(index);
//        }
//    }

//}
