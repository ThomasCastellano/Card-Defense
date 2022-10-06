using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGrid : MonoBehaviour
{
    public TileContainer tileContainerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (tileContainerPrefab != null)
        {
            GridLayout grid = this.GetComponent<GridLayout>();
            //grid.cellSize.x = 

            for (int i = 0; i < BoardModel.SIZE_ROW; i++)
            {
                for (int j = 0; j < BoardModel.SIZE_COL; j++)
                {
                    TileContainer tileContainer = Instantiate(tileContainerPrefab, transform);
                    tileContainer.Row = i;
                    tileContainer.Col = j;
                    //tileContainer.transform.localPosition = Vector3.zero;
                    GameManager.instance.tileContainers.Add(tileContainer);
                }
            }
        }
    }
}
