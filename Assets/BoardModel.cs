
public class BoardModel
{
    const int SIZE_X = 4;
    const int SIZE_Y = 8;

    Tile[,] _Board = new Tile[SIZE_X, SIZE_Y];     // Plateau de jeu

    public static bool needRefresh = false;

    public void addEnnemy()
    {
        // Si la première est pleine, on ne rajoute pas d'ennemis
        int nbRows = _Board.Length;
        int nbCols = _Board[0].Length;
    }
}
