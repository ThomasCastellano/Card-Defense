using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BoardModel
{
    public const int SIZE_ROW = 8;
    public const int SIZE_COL = 4;
    //public const int MAX_NUMBER_OF_ENNEMIES = 12;
    //public const int TILE_MAX_OVERLAP = 1; // TODO : Superposition de Tiles

    // Plateau de jeu
    // Tableau 2D contenant une liste des Tiles à chaque emplacement
    // TODO : Les Tiles peuvent se superposés (ex: un piège et un ennemi)
    public static BoardModel instance;
    public static Tile[,] _Board = new Tile[SIZE_ROW, SIZE_COL];    
    public static List<Ennemy> _lEnnemies = new List<Ennemy>();          // Liste des references sur les ennemis en jeu
    public static List<TrapTile> _lTraps = new List<TrapTile>();          // Liste des references sur les pièges en jeu
    public static bool _NeedRefresh = false;    // Pour refresh la visu
    public static bool needDestroy = false;
    //public static float _CycleTime = 3.0f;      // Temps entre l'ajout de deux ennemis

    private float _TimerStart = 0.0f;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public BoardModel()
    {
        BuildBoard();
        instance = this;
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
        _NeedRefresh = false;
    }

    // ----------------------------------------------
    // DeleteFlaggedTiles
    // ----------------------------------------------
    // Supprime les Tiles marquées avec le flag _ToDestroyFlag
    public void DestroyFlaggedTiles()
    {
        foreach (Ennemy ennemy in _lEnnemies)
        {
            if (ennemy.ToDestroyFlag)
            {
                int RowPos = ennemy.Row;
                int ColPos = ennemy.Col;
                _Board[RowPos, ColPos] = new Tile(RowPos, ColPos);
            }
        }
        _lEnnemies.RemoveAll(x => x.ToDestroyFlag);

        foreach (TrapTile trap in _lTraps)
        {
            if (trap.ToDestroyFlag)
            {
                int RowPos = trap.Row;
                int ColPos = trap.Col;
                _Board[RowPos, ColPos] = new Tile(RowPos, ColPos);
            }
        }
        _lTraps.RemoveAll(x => x.ToDestroyFlag);

        needDestroy = false;
    }

    // ----------------------------------------------
    // AddEnnemy
    // ----------------------------------------------
    public void AddEnnemy()
    {
        int nCol = Random.Range(0,4);
        // Si la case est prise par un ennemi, on ne rajoute pas d'ennemis dessus
        if (_Board[0, nCol].GetType().Name == "Ennemy") return;

        Ennemy newEnnemy = new Ennemy(0, nCol, 1, 3, 1, EnnemyType.BEAR);
        _Board[0, nCol] = newEnnemy;
        _lEnnemies.Add(newEnnemy);
        _NeedRefresh = true;
        _TimerStart = Time.time;
    }

    // ----------------------------------------------
    // AddTrapFromCard
    // ----------------------------------------------
    // Fait le lien entre une carte piège et l'objet piège
    // lorsque la carte est jouée
    public void AddTrapFromCard(TrapModel iTrapCard, int iRow, int iCol)
    {
        // Crée un piège du même type que la carte jouée
        TrapTile trap = new TrapTile(iRow, iCol, iTrapCard.damage, iTrapCard.trapType);
        _Board[iRow, iCol] = trap;
        _lTraps.Add(trap);
        _NeedRefresh = true;
    }

    // ----------------------------------------------
    // MoveEnnemies
    // ----------------------------------------------
    public void MoveEnnemies()
    {
        foreach (Ennemy ennemy in _lEnnemies)
        {
            if (ennemy == null)
            {
                Debug.LogError("Null Ennemy");
                return;
            }

            int OldEnnemyRowPos = ennemy.Row;
            int OldEnnemyColPos = ennemy.Col;

            // Déplace l'ennemi et vérifie qu'il n'a pas été bloqué par un autre ennemi
            if (ennemy.MoveDown() == true)
            {
                int NewEnnemyRowPos = ennemy.Row;
                int NewEnnemyColPos = ennemy.Col;

                // Si l'ennemi vient de se placer sur une Tile piege, il l'active et la détruit
                string sOldTileType = _Board[NewEnnemyRowPos, NewEnnemyColPos].GetType().Name;
                if (sOldTileType == "Trap")
                {
                    TrapTile TrapTile = (TrapTile)_Board[NewEnnemyRowPos, NewEnnemyColPos];
                    TrapTile.Activate(ennemy);
                    TrapTile.ToDestroyFlag = true;
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = new Tile(OldEnnemyRowPos, OldEnnemyColPos);
                }
                else
                {
                    // Si c'est une Tile vide on la replace là où l'ennemi était
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = _Board[NewEnnemyRowPos, NewEnnemyColPos];
                }

                // Move la Tile de l'ennemi sur le board
                _Board[NewEnnemyRowPos, NewEnnemyColPos] = ennemy;
                _NeedRefresh = true;
            }
        }
    }
    
    public Tile GetTile(int Row, int Col)
    {
        return _Board[Row, Col];
    }

}
