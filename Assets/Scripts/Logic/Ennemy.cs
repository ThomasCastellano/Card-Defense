using UnityEngine;
public class Ennemy : Tile
{
    public int _nHp;         // Heath
    public int _nMovement;   // Distance de d�placement max
    public float _fSpeed;    // Temps entre deux d�placements

    private float MovementTimer = 2.0f;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Ennemy(int iRow, int iCol , int iHP, int iSpeed, int iMovement) : base(iRow, iCol)
    {
        _nHp = iHP;
        _fSpeed = iSpeed;
        _nMovement = iMovement;
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
        if (Time.time - MovementTimer > _fSpeed)
        {
            // Port� du mouvement random
            int nMove = Random.Range(0, _nMovement+1);
            while (nMove + _nRowPos > 7)
            {
                nMove--;
            }

            // Si pas d'ennemi sur la case
            if (nMove > 0 && _nRowPos < 7)
            {
                if (BoardModel._Board[_nRowPos + nMove, _nColPos].GetType().Name != "Ennemy")
                {
                    _nRowPos += nMove;
                    MovementTimer = Time.time;
                    BoardModel._NeedRefresh = true;
                    return true;
                }
            }
        }
        return false;
    }
}
