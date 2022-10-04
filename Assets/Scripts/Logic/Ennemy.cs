using UnityEngine;
public class Ennemy : Tile
{
    public int Hp;         // Heath
    public int Movement;   // Distance de d�placement max
    public float Speed;    // Temps entre deux d�placements
    public EnnemyType type;

    private float _MovementTimer = 0f;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Ennemy(int iRow, int iCol , int iHP, int iSpeed, int iMovement, EnnemyType iType) : base(iRow, iCol)
    {
        Hp = iHP;
        Speed = iSpeed;
        Movement = iMovement;
        type = iType;
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
            int nMove = Random.Range(0, Movement+1);
            while (nMove + Row > 7)
            {
                nMove--;
            }

            // Si pas d'ennemi sur la case on d�place
            if (nMove > 0 && Row < 7)
            {
                if (BoardModel._Board[Row + nMove, Col].GetType().Name != "Ennemy")
                {
                    Row += nMove;
                    _MovementTimer = 0;
                    BoardModel._NeedRefresh = true;
                    return true;
                }
            }
        }

        if (Row >= BoardModel.SIZE_ROW)
        {
            // TODO: Bloquer une carte pour le joueur

            ToDestroyFlag = true;
        }

        _MovementTimer += Time.deltaTime;
        return false;
    }
}
