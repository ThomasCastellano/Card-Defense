using UnityEngine;
public class Ennemy : Tile
{
    public int hp;         // Heath
    public int movement;   // Distance de déplacement max
    public float _fSpeed;  // Temps entre deux déplacements

    private float MovementTimer;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Ennemy(int iRow, int iCol, int iHP, int iSpeed, int iMovement)
    {
        _nRowPos = iRow;
        _nColPos = iCol;
        hp = iHP;
        _fSpeed = iSpeed;
        movement = iMovement;
    }

    // ----------------------------------------------
    // MoveDown
    // ----------------------------------------------
    public void MoveDown()
    {
        if (MovementTimer - Time.time > _fSpeed)
        {
            RowPos++;
            MovementTimer = Time.time;
            BoardModel.needRefresh = true;
        }
    }
}
