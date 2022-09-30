using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class BoardModel
{
    const int SIZE_ROW = 8;
    const int SIZE_COL = 4;
    const int SIZE_HAND = 4;
    const int MAX_NUMBER_OF_ENNEMIES = 12;
    const int TILE_MAX_OVERLAP = 1; // TODO : Superposition de Tiles

    // Plateau de jeu
    // Tableau 2D contenant une liste des Tiles � chaque emplacement
    // TODO : Les Tiles peuvent se superpos�s (ex: un pi�ge et un ennemi)
    public static Tile[,] _Board = new Tile[SIZE_ROW, SIZE_COL];    
    public static ArrayList _lEnnemies = new ArrayList();          // Liste des references sur les ennemis en jeu
    public static ArrayList _lPlayerHand = new ArrayList();        // Main du joueur
    public static bool _NeedRefresh = false;    // Pour refresh la visu
    public static float _CycleTime = 3.0f;      // Temps entre l'ajout de deux ennemis

    private float _TimerStart = 0.0f;


    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public BoardModel()
    {
        BuildBoard();
    }

    // ----------------------------------------------
    // BuildBoard
    // ----------------------------------------------
    public void BuildBoard()
    {
        for (int i = 0; i < SIZE_ROW; i++)
        {
            for (int j = 0; j < SIZE_COL; j++)
            {
                _Board[i, j] = new Tile(i, j);
            }
        }
    }

    public void BuildHand()
    {
        for (int i = 0; i < SIZE_HAND; i++)
        {
            //_lPlayerHand.Add(new TrapCard(i, i));
        }
    }

    // ----------------------------------------------
    // UpdateBoard
    // ----------------------------------------------
    public void UpdateBoard()
    {
        

    }

    // ----------------------------------------------
    // RefreshDisplay
    // ----------------------------------------------
    public void RefreshDisplay()
    {
        System.Text.StringBuilder str = new System.Text.StringBuilder();
        for (int i = 0; i < SIZE_ROW; i++)
        {
            for (int j = 0; j < SIZE_COL; j++)
            {
                string sTileType = _Board[i, j].GetType().Name;
                if (sTileType == "Tile")
                    str.Append(" -");
                if (sTileType == "Ennemy")
                    str.Append(" x");
                if (sTileType == "Trap")
                    str.Append(" o");
            }
            str.Append("\n");
        }
        Debug.Log(str.ToString());
    }

    // ----------------------------------------------
    // AddEnnemy
    // ----------------------------------------------
    public void AddEnnemy()
    {
        if (Time.time - _TimerStart < _CycleTime  || _lEnnemies.Count >= MAX_NUMBER_OF_ENNEMIES) return;

        int nCol = Random.Range(0,4);
        // Si la case est prise par un ennemi, on ne rajoute pas d'ennemis dessus
        if (_Board[0, nCol].GetType().Name == "Ennemy") return;

        Ennemy newEnnemy = new Ennemy(0, nCol, 1, 2, 1);
        _Board[0, nCol] = newEnnemy;
        _lEnnemies.Add(newEnnemy);
        _NeedRefresh = true;
        _TimerStart = Time.time;
    }

    public void AddTrapFromCard(TrapCard Card)
    {
        //if (Card) ;
    }

    // ----------------------------------------------
    // MoveEnnemies
    // ----------------------------------------------
    public void MoveEnnemies()
    {
        foreach (Ennemy ennemy in _lEnnemies)
        {
            int OldEnnemyRowPos = ennemy._nRowPos;
            int OldEnnemyColPos = ennemy._nColPos;

            // D�place l'ennemi et v�rifie qu'il n'a pas �t� bloqu� par un autre ennemi
            if (ennemy.MoveDown() == true)
            {
                int NewEnnemyRowPos = ennemy._nRowPos;
                int NewEnnemyColPos = ennemy._nColPos;

                // Si l'ennemi vient de se placer sur une Tile piege, il l'active et la d�truit
                string sOldTileType = _Board[NewEnnemyRowPos, NewEnnemyColPos].GetType().Name;
                if (sOldTileType == "Trap")
                {
                    Trap TrapTile = (Trap)_Board[NewEnnemyRowPos, NewEnnemyColPos];
                    TrapTile.Activate(ennemy);
                    TrapTile._ToDestroyFlag = true;
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = new Tile(OldEnnemyRowPos, OldEnnemyColPos);
                }
                else
                {
                    // Si c'est une Tile vide on la replace l� o� l'ennemi �tait
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = _Board[NewEnnemyRowPos, NewEnnemyColPos];
                }

                // Move la Tile de l'ennemi sur le board
                _Board[NewEnnemyRowPos, NewEnnemyColPos] = ennemy;
                _NeedRefresh = true;
            }
        }
    }
    

}
