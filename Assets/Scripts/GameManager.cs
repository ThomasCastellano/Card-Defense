using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float _SpawnDelay = 5.0f;      // Temps entre l'ajout de deux ennemis
    public const int MAX_NUMBER_OF_ENNEMIES = 12;

    public StateMachine State;
    public GameObject playGrid;
    public PlayerHand playerHand;

    public TileContainer tileContainerPrefab;
    public List<TileContainer> tileContainers = new List<TileContainer>();

    private BoardModel _boardModel;
    private PlayerHandModel _playerHandModel;

    private float _SpawnTimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _boardModel = new BoardModel();
        _playerHandModel = new PlayerHandModel();

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
            foreach(TileContainer tile in tileContainers)
            {
                tile.Refresh();
            }
        }

        if (_playerHandModel.needRefresh)
        {
            playerHand.Refresh();
            _playerHandModel.needRefresh = false;
        }
    }

    [ContextMenu("PlayTrapCard")]
    void PlayTrapCard()
    {
        BearTrap trap = new BearTrap();
        _boardModel.AddTrapFromCard(trap, Random.Range(0, 7), Random.Range(0, 3));
    }

    [ContextMenu("Refresh")]
    void RefreshDisplay()
    {
        _boardModel.RefreshDisplay();
    }
}
