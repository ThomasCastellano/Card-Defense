public class Ennemy
{
    private int hp;         // Heath
    private int speed;      // Temps entre deux déplacements
    private int movement;   // Distance de déplacement max

    private int RowPos;     // Position dans le tableau
    private int ColPos;

    private int 

    public Ennemy(int iHP, int iSpeed, int iMovement)
    {
        hp = iHP;
        speed = iSpeed;
        movement = iMovement;
    }

    // Getters & Setters
    public int GetHP() { return hp; }
    public void SetHP(int iValue) 
    { 
        hp = iValue; 
    }
    public int GetSpeed() { return speed; }
    public void SetSpeed(int iValue)
    {
        speed = iValue;
    }
    public int GetMovement() { return movement; }
    public void SetMovement(int iValue)
    {
        movement = iValue;
    }
}
