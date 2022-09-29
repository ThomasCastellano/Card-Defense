using UnityEngine;
using UnityEngine.Rendering;

public class BoardModel
{
    const int SIZE_ROW = 8;
    const int SIZE_COL = 4;

    public Tile[,] _Board = new Tile[SIZE_ROW, SIZE_COL];     // Plateau de jeu
    public static bool _NeedRefresh = false;     // Pour refresh la visu
    public static int _NbEnnemies = 0;
    public static float _CycleTime = 2.0f;

    private float _TimerStart = 0.0f;

    public BoardModel()
    {
        //System.Console.WriteLine("Test");
        BuildBoard();
    }

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

    public void AddEnnemy()
    {
        if (Time.time - _TimerStart > _CycleTime) return;

        int nCol = Random.Range(0,4);
        // Si la première est pleine, on ne rajoute pas d'ennemis
        if (_Board[0, nCol].GetType().Name == "Ennemy") return;

        _Board[0, nCol] = new Ennemy(0, nCol, 1, 1, 1);
        _NbEnnemies++;
        _NeedRefresh = true;
        _TimerStart = Time.time;
    }

    public void MoveEnnemies()
    {
        for (int i = 0; i < SIZE_ROW; i++)
        {
            for (int j = 0; j < SIZE_COL; j++)
            {
                string sTileType = _Board[i, j].GetType().Name;
                if (sTileType == "Ennemy")
                    ((Ennemy)_Board[i, j]).MoveDown();
            }
        }
    }

    /*
    private bool IsEnnemyRowFull()
    {
        for (int j = 0; j < SIZE_COL; j++)
        {
            if (_Board[0, j].GetType().Name == "Tile") 
                return false;
        }
        return true;
    }
    */
}
