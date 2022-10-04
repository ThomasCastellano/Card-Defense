using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileContainer : MonoBehaviour
{
    public int Row;
    public int Col;
    public bool isfull;

    public BoardModel boardModel;
    //public Image backgroundImage;

    public GameObject bearPrefab;

    private void Start()
    {
        boardModel = BoardModel.instance;
    }

    public void Refresh()
    {
        Tile tile = boardModel.GetTile(Row, Col);

        if (tile is Ennemy ennemy)
        {
            switch(ennemy.type)
            {
                case EnnemyType.BEAR:
                    {
                        GameObject ennemyGO = Instantiate(bearPrefab, transform);
                        ennemyGO.transform.localPosition = Vector3.zero;
                        break;
                    }
                default:
                    {
                        // on detruit la carte inutile
                        foreach(Transform child in transform)
                        {
                            Destroy(child);
                        }
                        break;
                    }
            }
        }
        else if (tile is Trap trap)
        {

        }
        else
        {
            // Reset la tile
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

   public void OnTriggerEnter2D(Collider2D collision)
   {
         //if (gameManager.draggingObject !=null && isfull == false)
        {
            //gameManager.currentContainer = this.gameObject;
            //backgroundImage.enabled = true;
        }
   }

   public void OnTriggerExit2D(Collider2D collision)
   {
        //gameManager.currentContainer = null;
        //backgroundImage.enabled = false;
   }
}
