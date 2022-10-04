using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int MAX_NUMBER_OF_ENNEMIES = 12;

    public StateMachine State;
    public GameObject playGrid;
    public TileContainer tileContainerPrefab;

    public static float _SpawnDelay = 5.0f;      // Temps entre l'ajout de deux ennemis

    private BoardModel _boardModel;
    private PlayerHandModel _playerHandModel;
    private List<TileContainer> _tileContainers = new List<TileContainer>();

    private float _SpawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _boardModel = new BoardModel();
        _playerHandModel = new PlayerHandModel();

        InitPlayGrid();
    }

    // Update is called once per frame
    void Update()
    {
        _boardModel.MoveEnnemies();

        if (BoardModel.needDestroy)
        {
            _boardModel.DestroyFlaggedTiles();
        }

        if (_SpawnTimer > _SpawnDelay && BoardModel._lEnnemies.Count < MAX_NUMBER_OF_ENNEMIES)
        {
            _boardModel.AddEnnemy();
            _SpawnTimer = 0;
        }
        _SpawnTimer += Time.deltaTime;

        if (BoardModel._NeedRefresh)
        {
            _boardModel.RefreshDisplay();
            foreach(TileContainer tile in _tileContainers)
            {
                tile.Refresh();
            }
        }
    }

    void InitPlayGrid()
    {
        if (playGrid != null && tileContainerPrefab != null)
        {
            GridLayout grid = playGrid.GetComponent<GridLayout>();
            //grid.cellSize.x = 

            for (int i = 0; i < BoardModel.SIZE_ROW; i++)
            {
                for (int j = 0; j < BoardModel.SIZE_COL; j++)
                {
                    TileContainer tileContainer = Instantiate(tileContainerPrefab, playGrid.transform);
                    tileContainer.Row = i;
                    tileContainer.Col = j;
                    //tileContainer.transform.localPosition = Vector3.zero;
                    _tileContainers.Add(tileContainer);
                }
            }
        }
    }

    [ContextMenu("PlayTrapCard")]
    void PlayTrapCard()
    {
        BearTrapCard card = new BearTrapCard();
        _boardModel.AddTrapFromCard(card, Random.Range(0, 7), Random.Range(0, 3));
    }

    [ContextMenu("Refresh")]
    void RefreshDisplay()
    {
        _boardModel.RefreshDisplay();
    }
}
