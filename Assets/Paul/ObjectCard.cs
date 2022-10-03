using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;

    private GameObject objectDragInstance;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate (object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;
        gameManager.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Place l'objet sur le board
        gameManager.PlaceObject();

        // D�truit l'objet de drag n drop
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
        


    }

    
 
}


