public enum OBSTACLE_TYPE
{
    TRAP,
    LEAVES,
    FOG,
    SNOW
}

public class Obstacle : Tile
{
    // Constructeur prot�g�
    protected Obstacle(int iRow, int iCol) : base(iRow, iCol)
    {

    }
}
