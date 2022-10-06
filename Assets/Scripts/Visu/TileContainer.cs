using System.Collections;
using System.Collections.Generic;
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

    public GameObject bearTrapPrefab;
    public GameObject netTrapPrefab;

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
                        break;
                    }
                case EnnemyType.GNOME:
                    {
                        GameObject ennemyGO = Instantiate(gnomePrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
                    /*
                default:
                    {
                        // on detruit la carte inutile
                        foreach(Transform child in transform)
                        {
                            Destroy(child);
                        }
                        break;
                    }
                    */
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
    }
}
