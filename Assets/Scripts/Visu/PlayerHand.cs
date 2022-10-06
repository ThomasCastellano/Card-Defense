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
        foreach (ItemModel itemModel in PlayerHandModel.instance.lPlayerHand)
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
            if (itemType == ItemType.TRAP)
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

        }
    }
}
