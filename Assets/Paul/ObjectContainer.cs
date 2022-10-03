using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectContainer : MonoBehaviour
{
    public int Row;
    public int Col;

    public bool isfull;
    public GameManager gameManager;
    public Image backgroundImage;

    public GameObject tortuePrefab;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Refresh()
    {
        Tile tile = gameManager.GetTile(Row, Col);

        if (tile is Ennemy ennemy)
        {
            switch(ennemy.type)
            {
                case Types.Tortue:
                    {
                        GameObject ennemy = Instantiate(tortuePrefab, transform);
                        ennemy.transform.localPosition = Vector3.zero;
                        break;
                    }
                default:
                    {
                        // on detruit la carte inutile
                        foreach(Transform child in transform)
                        {
                            Destroy(child);
                        }
                    }

            }

        }




    }

   
   public void OnTriggerEnter2D(Collider2D collision)
   {
         if (gameManager.draggingObject !=null && isfull == false)
        {
            gameManager.currentContainer = this.gameObject;
            backgroundImage.enabled = true;
        }
   }

   public void OnTriggerExit2D(Collider2D collision)
   {
        gameManager.currentContainer = null;
        backgroundImage.enabled = false;
   }
}
