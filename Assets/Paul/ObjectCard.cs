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

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate (object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        GameManager.instance.draggingObject = objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.instance.draggingObject = null;
       Destroy(objectDragInstance);
    }

    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;
    }
 
}


