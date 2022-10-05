using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject bearTrapCardPrefab;
    public GameObject netTrapCardPrefab;
    public GameObject spearCardPrefab;
    public GameObject torchCardPrefab;
    public GameObject mercenaryCardPrefab;
    public GameObject rexCardPrefab;
    public GameObject snowmanCardPrefab;
    public GameObject scarecrowCardPrefab;
    public GameObject restoreCardPrefab;

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
        foreach (ItemModel card in PlayerHandModel.instance.lPlayerHand)
        {
            CardType cardType = card.type;
            GameObject gameObject = null;

            // Cartes WEAPON
            if (cardType == CardType.WEAPON)
            {
                WeaponModel weaponCard = (WeaponModel)card;
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
            if (cardType == CardType.TRAP)
            {
                TrapModel trapCard = (TrapModel)card;

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

        }
    }
}
