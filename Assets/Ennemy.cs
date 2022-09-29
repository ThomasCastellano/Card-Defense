using UnityEngine;
public class Ennemy : Tile
{
    public int _nHp;         // Heath
    public int _nMovement;   // Distance de déplacement max
    public float _fSpeed;  // Temps entre deux déplacements

    private float MovementTimer;

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
    public void MoveDown()
    {
        if (MovementTimer - Time.time > _fSpeed)
        {
            _nRowPos++;
            MovementTimer = Time.time;
            BoardModel._NeedRefresh = true;
        }
    }
}
