using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVisuManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static GameVisuManager instance;

    private void Awake()
    {
        instance = this;
    } 

    public void PlaceObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            //currentContainer.GetComponent<ObjectContainer>().isfull = true;
        }
    }
}
