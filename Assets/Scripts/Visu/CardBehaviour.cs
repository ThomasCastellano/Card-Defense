using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    public ItemModel itemModel;   // logic
    public GameObject boardObject;  // visu

    public Vector3 originalAnchoredPosition;    // Original anchored position in player's hand to reset drag n drop
    public Vector3 originalPosition;            // Original position in player's hand to reset drag n drop

    public bool dragable = true;

    private BoardModel _boardModel;

    void Start()
    {
        _boardModel = BoardModel.instance;
        if (_boardModel == null)
        {
            Debug.LogError("No instance of BoardModel found");
        }
        originalAnchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        originalPosition = transform.position;
    }
}
