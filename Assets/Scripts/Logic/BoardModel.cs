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
    // Tableau 2D contenant une liste des Tiles � chaque emplacement
    // TODO : Les Tiles peuvent se superpos�s (ex: un pi�ge et un ennemi)
    public static BoardModel instance;

    public Tile[,] _Board = new Tile[SIZE_ROW, SIZE_COL];    
    public List<EnnemyTile> _lEnnemyTile = new List<EnnemyTile>();          // Liste des references sur les ennemis en jeu
    public List<ItemTile> _lItemTile = new List<ItemTile>();          // Liste des references sur les pi�ges en jeu
    public bool _NeedRefresh = false;    // Pour refresh la visu
    public bool needDestroy = false;
    //public float _CycleTime = 3.0f;      // Temps entre l'ajout de deux ennemis

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
    // RefreshDisplay
    // ----------------------------------------------
    public void RefreshDisplay()
    {
        System.Text.StringBuilder str = new System.Text.StringBuilder();
        for (int i = 0; i < SIZE_ROW; i++)
        {
            for (int j = 0; j < SIZE_COL; j++)
            {
                TileType tileType = _Board[i, j].tileType;
                if (tileType == TileType.EMPTY)
                    str.Append(" -");
                if (tileType == TileType.ENNEMY)
                    str.Append(" x");
                if (tileType == TileType.TRAP)
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
    // Supprime les Tiles marqu�es avec le flag _ToDestroyFlag
    public void DestroyFlaggedTiles()
    {
        foreach (EnnemyTile ennemy in _lEnnemyTile)
        {
            if (ennemy.ToDestroyFlag)
            {
                int RowPos = ennemy.Row;
                int ColPos = ennemy.Col;
                _Board[RowPos, ColPos] = new Tile(RowPos, ColPos);
            }
        }
        _lEnnemyTile.RemoveAll(x => x.ToDestroyFlag);

        foreach (ItemTile itemTile in _lItemTile)
        {
            if (itemTile.ToDestroyFlag)
            {
                int RowPos = itemTile.Row;
                int ColPos = itemTile.Col;
                _Board[RowPos, ColPos] = new Tile(RowPos, ColPos);
            }
        }
        _lItemTile.RemoveAll(x => x.ToDestroyFlag);

        needDestroy = false;
    }

    // ----------------------------------------------
    // AddEnnemy
    // ----------------------------------------------
    public void AddEnnemy()
    {
        int nCol = Random.Range(0,4);
        // Si la case est prise par un ennemi, on ne rajoute pas d'ennemis dessus
        if (_Board[0, nCol].tileType == TileType.ENNEMY) return;

        // Random ennemy
        EnnemyType ennemyType = (EnnemyType)Random.Range(0, 2);

        Ennemy ennemyModel = null;
        EnnemyTile ennemyTile = null;

        switch (ennemyType)
        {
            case EnnemyType.BEAR:
                {
                    ennemyModel = new BearEnnemy();
                    ennemyTile = new EnnemyTile(0, nCol, TileType.ENNEMY, ennemyModel, ennemyModel.ennemyPrefab);
                    break;
                }
            case EnnemyType.GNOME:
                {
                    ennemyModel = new GnomeEnnemy();
                    ennemyTile = new EnnemyTile(0, nCol, TileType.ENNEMY, ennemyModel, ennemyModel.ennemyPrefab);
                    break;
                }
        }

        if (ennemyModel != null)
        {
            ennemyModel.tile = ennemyTile;
            //_Board[0, nCol] = newEnnemy.CreateTile(0, nCol);
            //ennemyTile = new EnnemyTile(0, nCol, TileType.ENNEMY, newEnnemy, newEnnemy.tile.objectPrefab);
            //_Board[0, nCol] = new EnnemyTile(0, nCol, TileType.ENNEMY, newEnnemy, newEnnemy.tile.objectPrefab);
            _Board[0, nCol] = ennemyTile;
            _lEnnemyTile.Add(ennemyTile);
            _NeedRefresh = true;
            _TimerStart = Time.time;
        }
    }

    // ----------------------------------------------
    // AddTrapFromCard
    // ----------------------------------------------
    // Fait le lien entre une carte pi�ge et l'objet pi�ge
    // lorsque la carte est jou�e
    /*
    public void AddTrapFromCard(TrapModel iTrapCard, int iRow, int iCol)
    {
        // Cr�e un pi�ge du m�me type que la carte jou�e
        TrapTile trap = new TrapTile(iRow, iCol, iTrapCard.damage, iTrapCard.trapType);
        _Board[iRow, iCol] = trap;
        _lItemTile.Add(trap);
        _NeedRefresh = true;
    }
    */


    // ----------------------------------------------
    // PlayCard
    // ----------------------------------------------
    //public void PlayCard(CardBehaviour card, int iRow, int iCol)
    //{
    //    ItemModel itemModel = card.itemModel;
    //    GameObject objectPrefab = card.boardObject;

    //    if (itemModel == null)
    //    {
    //        Debug.LogError("No ItemModel found for the played card");
    //        return;
    //    }

    //    if (itemModel is WeaponModel)
    //    {
    //        WeaponModel weaponModel = (WeaponModel)itemModel;

    //        Tile tile = _Board[iRow, iCol];
    //        if (tile.tileType == TileType.ENNEMY)
    //        {
    //            Ennemy ennemyModel = ((EnnemyTile)tile).ennemyModel;
    //            weaponModel.Activate(ennemyModel);
    //        }
    //    }

    //    if (itemModel is TrapModel)
    //    {
    //        TrapModel trapModel = (TrapModel)itemModel;

    //        // Cr�e un pi�ge du m�me type que la carte jou�e
    //        ItemTile trap = new ItemTile(iRow, iCol, TileType.TRAP, trapModel, objectPrefab);
    //        _Board[iRow, iCol] = trap;
    //        _lItemTile.Add(trap);
    //        _NeedRefresh = true;
    //    }
    //    else if (itemModel is AllyModel)
    //    {
    //        AllyModel allyModel = (AllyModel)itemModel;

    //        // Cr�e un pi�ge du m�me type que la carte jou�e
    //        ItemTile trap = new ItemTile(iRow, iCol, TileType.ALLY, allyModel, objectPrefab);
    //        _Board[iRow, iCol] = trap;
    //        _lItemTile.Add(trap);
    //        _NeedRefresh = true;
    //    }
    //}

    // ----------------------------------------------
    // MoveEnnemies
    // ----------------------------------------------
    public void MoveEnnemies()
    {
        foreach (EnnemyTile ennemyTile in _lEnnemyTile)
        {
            Ennemy ennemy = ennemyTile.ennemyModel;
            if (ennemy == null)
            {
                Debug.LogError("Null Ennemy Model");
                return;
            }

            int OldEnnemyRowPos = ennemyTile.Row;
            int OldEnnemyColPos = ennemyTile.Col;

            // D�place l'ennemi et v�rifie qu'il n'a pas �t� bloqu� par un autre ennemi
            if (ennemy.MoveDown() == true)
            {
                int NewEnnemyRowPos = ennemyTile.Row;
                int NewEnnemyColPos = ennemyTile.Col;

                // Si l'ennemi vient de se placer sur une Tile piege, il l'active et la d�truit
                Tile oldTile = _Board[NewEnnemyRowPos, NewEnnemyColPos];
                if (oldTile.tileType == TileType.TRAP)
                {
                    TrapModel trapModel = (TrapModel)((ItemTile)oldTile).itemModel;
                    trapModel.Activate(ennemy);
                    trapModel.tile.ToDestroyFlag = true;
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = new Tile(OldEnnemyRowPos, OldEnnemyColPos);
                }
                else
                {
                    // Si c'est une Tile vide on la replace l� o� l'ennemi �tait
                    _Board[OldEnnemyRowPos, OldEnnemyColPos] = _Board[NewEnnemyRowPos, NewEnnemyColPos];
                }

                // Move la Tile de l'ennemi sur le board
                _Board[NewEnnemyRowPos, NewEnnemyColPos] = ennemy.tile;
                _NeedRefresh = true;
            }
        }
    }
    
    public Tile GetTile(int Row, int Col)
    {
        return _Board[Row, Col];
    }

}
