using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuGameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static VisuGameManager instance;

    private void Awake()
    {
        instance = this;
    } 

    public void PlaceObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            currentContainer.GetComponent<TileContainer>().isfull = true;
        }
    }
}
