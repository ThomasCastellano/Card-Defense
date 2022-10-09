using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TileContainer : MonoBehaviour
{
    public int Row;
    public int Col;
    //public bool isfull;

    public BoardModel boardModel;

    public GameObject bearPrefab;
    public GameObject gnomePrefab;
    public GameObject boarPrefab;
    public GameObject squirrelPrefab;

    public GameObject bearTrapPrefab;
    public GameObject netTrapPrefab;
    public GameObject snowmanPrefab;
    public GameObject scarecrowPrefab;
    public GameObject rexPrefab;
    public GameObject mercenaryPrefab;

    private void Start()
    {
        boardModel = BoardModel.instance;
    }

    public void Refresh()
    {
        Tile tile = boardModel.GetTile(Row, Col);

        // Reset la tile
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        if (tile.tileType == TileType.ENNEMY)
        {
            Ennemy ennemy = ((EnnemyTile)tile).ennemyModel;
            switch (ennemy.ennemyType)
            {
                case EnnemyType.BEAR:
                    {
                        GameObject ennemyGO = Instantiate(bearPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = ennemy.Hp.ToString();
                        break;
                    }
                case EnnemyType.GNOME:
                    {
                        GameObject ennemyGO = Instantiate(gnomePrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = ennemy.Hp.ToString();
                        break;
                    }
                case EnnemyType.BOAR:
                    {
                        GameObject ennemyGO = Instantiate(boarPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = ennemy.Hp.ToString();
                        break;
                    }
                case EnnemyType.SQUIRREL:
                    {
                        GameObject ennemyGO = Instantiate(squirrelPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = ennemy.Hp.ToString();
                        break;
                    }
            }
        }
        else if (tile.tileType == TileType.TRAP)
        {
            TrapModel itemModel = (TrapModel)((ItemTile)tile).itemModel;
            switch (itemModel.trapType)
            {
                case TrapType.BEAR_TRAP:
                    {
                        GameObject ennemyGO = Instantiate(bearTrapPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
                case TrapType.NET_TRAP:
                    {
                        GameObject ennemyGO = Instantiate(netTrapPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
            }
        }
        else if (tile.tileType == TileType.ALLY)
        {
            AllyModel itemModel = (AllyModel)((ItemTile)tile).itemModel;
            switch (itemModel.allyType)
            {
                case AllyType.REX_DOG:
                    {
                        GameObject ennemyGO = Instantiate(rexPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = itemModel.damage.ToString();
                        break;
                    }
               case AllyType.MERCENARY:
                    {
                        GameObject ennemyGO = Instantiate(mercenaryPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        ennemyGO.GetComponentInChildren<TextMeshProUGUI>().text = itemModel.damage.ToString();
                        break;
                    }
            }
        }
        else if (tile.tileType == TileType.DIVERSION)
        {
            DiversionModel itemModel = (DiversionModel)((ItemTile)tile).itemModel;
            switch (itemModel.diversionType)
            {
                case DiversionType.SNOWMAN:
                    {
                        GameObject ennemyGO = Instantiate(snowmanPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
                case DiversionType.SCARECROW:
                    {
                        GameObject ennemyGO = Instantiate(scarecrowPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
            }
        }
    }
}
