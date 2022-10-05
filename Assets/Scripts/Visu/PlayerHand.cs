using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject beartrapCardPrefab;

    private PlayerHandModel _PlayerHandModel;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerHandModel = PlayerHandModel.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        foreach (Card card in PlayerHandModel.instance.lPlayerHand)
        {
            CardType cardType = card.type;

            // Cartes WEAPON
            if (cardType == CardType.WEAPON)
            {
                WeaponCard weaponCard = (WeaponCard)card;
                switch (weaponCard.weaponType)
                {
                    case WeaponType.HUNTING_RIFLE:
                        break;
                }
            }

            // Cartes TRAP
            if (cardType == CardType.TRAP)
            {
                TrapCard trapCard = (TrapCard)card;
                switch (trapCard.trapType)
                {
                    case TrapType.BEAR_TRAP:
                        GameObject ennemyGO = Instantiate(beartrapCardPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                }
            }

        }
    }
}
