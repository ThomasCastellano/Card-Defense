using UnityEngine;
public class Ennemy
{
    public int Hp;         // Health
    public int Movement;   // Distance de d�placement max
    public float Speed;    // Temps entre deux d�placements
    public EnnemyType ennemyType;

    public EnnemyTile tile;

    public GameObject ennemyPrefab;

    private float _MovementTimer = 0f;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Ennemy(int iHP, int iSpeed, int iMovement, EnnemyType iType)
    {
        Hp = iHP;
        Speed = iSpeed;
        Movement = iMovement;
        ennemyType = iType;
    }

    // ----------------------------------------------
    // MoveDown
    // ----------------------------------------------
    // D�place l'ennemi vers le bas uniquement du cote de sa donn�e
    // Le d�placement dans le tableau est g�r� dans le BoardModel
    // @return True : the ennemy has been moved
    // @return False : the ennemy was unable to move
    public bool MoveDown()
    {
        if (_MovementTimer > Speed)
        {
            // Port� du mouvement random
            int Move = Random.Range(0, Movement+1);

            // Le monstre ne peut pas attaquer le joueur avec un saut de plus de 1
            if (Move > 0 && tile.Row == BoardModel.SIZE_ROW - 1)
            {
                Move = 1;
            }
            else
            {
                while (Move + tile.Row > BoardModel.SIZE_ROW - 1)
                {
                    Move--;
                }
            }

            if (Move > 0 && tile.Row < BoardModel.SIZE_ROW-1)
            {
                // Si pas d'ennemi sur la case on d�place
                if (BoardModel.instance._Board[tile.Row + Move, tile.Col].tileType != TileType.ENNEMY)
                {
                    tile.Row += Move;
                    BoardModel.instance._NeedRefresh = true;
                    _MovementTimer = 0;
                    return true;
                }
            }

        }

        if (tile.Row >= BoardModel.SIZE_ROW-1)
        {
            // TODO: Bloquer une carte pour le joueur

            tile.ToDestroyFlag = true;
            BoardModel.instance.needDestroy = true;
        }

        _MovementTimer += Time.deltaTime;
        return false;
    }

}
