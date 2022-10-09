using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float _SpawnDelay = 5.0f;      // Temps entre l'ajout de deux ennemis
    public const int MAX_NUMBER_OF_ENNEMIES = 12;
    public const float MAX_DIFFICULTY_MULTIPLIER = 4.0f;

    [SerializeField] private TextMeshProUGUI gameTimerGUI;

    public StateMachineGame StateMachine;
    public GameObject playGrid;
    public PlayerHand playerHand;
    public float difficultyMultiplier = 1.0f;

    public TileContainer tileContainerPrefab;
    public List<TileContainer> tileContainers = new List<TileContainer>();

    private BoardModel _boardModel;

    private float _gameTimer = 0f;
    private float _SpawnTimer = 0f;
    private float _DifficultyTimer = 0f;
    private int _NbBlockedCards = 0;

    // ----------------------------------------------
    // Awake
    // ----------------------------------------------
    private void Awake()
    {
        instance = this;
    }

    // ----------------------------------------------
    // Start
    // ----------------------------------------------
    void Start()
    {
        StateMachine = StateMachineGame.instance;
        _boardModel = new BoardModel();
        playerHand = PlayerHand.instance;
        _gameTimer = 0f;
    }

    // ----------------------------------------------
    // Update
    // ----------------------------------------------
    void Update()
    {
        // Update game timers
        if (_gameTimer < 9999f)
        {
            _gameTimer += Time.deltaTime;
            gameTimerGUI.text = _gameTimer.ToString("0.00") + " s";
        }

        // Increase difficulty every minute
        // 10 % increase every minute
        if (difficultyMultiplier < MAX_DIFFICULTY_MULTIPLIER && _DifficultyTimer > 60.0f)
        {
            _DifficultyTimer = 0f;
            difficultyMultiplier *= 1.1f;
            if (difficultyMultiplier > MAX_DIFFICULTY_MULTIPLIER)
            {
                difficultyMultiplier = MAX_DIFFICULTY_MULTIPLIER;
            }
            _SpawnDelay /= difficultyMultiplier;
            Debug.Log(difficultyMultiplier.ToString());
        }
        else
        {
            _DifficultyTimer += Time.deltaTime;
        }

        // Move ennemies
        _boardModel.MoveEnnemies();

        // Clean Board
        if (_boardModel.needDestroy)
        {
            _boardModel.DestroyFlaggedTiles();
        }

        // Spawn ennemies
        if (_SpawnTimer > _SpawnDelay && _boardModel._lEnnemyTile.Count < MAX_NUMBER_OF_ENNEMIES)
        {
            _boardModel.AddEnnemy();
            _SpawnTimer = 0;
        }
        _SpawnTimer += Time.deltaTime;

        // Refresh displayed objects
        if (_boardModel._NeedRefresh)
        {
            _boardModel.RefreshDisplay();
            foreach(TileContainer tile in tileContainers)
            {
                tile.Refresh();
            }
        }

        // Check if all cards are blocked for game over
        _NbBlockedCards = 0;
        for (int i = 0; i < playerHand.lIsCardPlayable.Count; i++)
        {
            if (playerHand.lIsCardPlayable[i] == false)
            {
                _NbBlockedCards++;
            }
        }
        if (_NbBlockedCards == playerHand.lIsCardPlayable.Count)
        {
            // GAME OVER YEAAAAH
            //Debug.Log("GAME OVER YEAAAAH");
            StateMachine.SetState(State.FIN);
            StateMachine.LoadScene("MainMenu");
        }
    }

    // ----------------------------------------------
    // PlayCard
    // ----------------------------------------------
    public void PlayCard(CardBehaviour card, int iRow, int iCol)
    {
        ItemModel itemModel = card.itemModel;
        GameObject objectPrefab = card.boardObject;

        if (itemModel == null)
        {
            Debug.LogError("No ItemModel found for the played card");
            return;
        }

        if (itemModel is WeaponModel)
        {
            WeaponModel weaponModel = (WeaponModel)itemModel;

            Tile tile = _boardModel._Board[iRow, iCol];
            if (tile.tileType == TileType.ENNEMY)
            {
                Ennemy ennemyModel = ((EnnemyTile)tile).ennemyModel;
                weaponModel.Activate(ennemyModel);
            }
        }

        if (itemModel is TrapModel)
        {
            TrapModel trapModel = (TrapModel)itemModel;

            // Crée un piège du même type que la carte jouée
            ItemTile trap = new ItemTile(iRow, iCol, TileType.TRAP, trapModel, objectPrefab);
            _boardModel._Board[iRow, iCol] = trap;
            _boardModel._lItemTile.Add(trap);
            trapModel.tile = trap;
            _boardModel._NeedRefresh = true;
        }
        else if (itemModel is AllyModel)
        {
            AllyModel allyModel = (AllyModel)itemModel;

            ItemTile ally = new ItemTile(iRow, iCol, TileType.ALLY, allyModel, objectPrefab);
            _boardModel._Board[iRow, iCol] = ally;
            _boardModel._lItemTile.Add(ally);
            allyModel.tile = ally;
            _boardModel._NeedRefresh = true;
        }
        else if (itemModel is DiversionModel)
        {
            DiversionModel diversionModel = (DiversionModel)itemModel;

            ItemTile diversion = new ItemTile(iRow, iCol, TileType.DIVERSION, diversionModel, objectPrefab);
            _boardModel._Board[iRow, iCol] = diversion;
            _boardModel._lItemTile.Add(diversion);
            diversionModel.tile = diversion;
            _boardModel._NeedRefresh = true;
        }

        playerHand.OnCardPlayed(card);
    }

    [ContextMenu("PlayTrapCard")]
    void PlayTrapCard()
    {
        BearTrap trap = new BearTrap();
        //_boardModel.AddTrapFromCard(trap, Random.Range(0, 7), Random.Range(0, 3));
    }

    [ContextMenu("Refresh")]
    void RefreshDisplay()
    {
        _boardModel.RefreshDisplay();
    }
}
