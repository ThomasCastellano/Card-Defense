using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy
{
    public int Hp;         // Health
    public int Movement;   // Distance de déplacement max
    public float Speed;    // Temps entre deux déplacements
    public EnnemyType ennemyType;

    public EnnemyTile tile;

    public GameObject ennemyPrefab;

    private float _MovementTimer = 0f;
    private float _BlockTimer = 0f;

    // ----------------------------------------------
    // Constructor
    // ----------------------------------------------
    public Ennemy(int iHP, float iSpeed, int iMovement, EnnemyType iType)
    {
        Hp = iHP;
        Speed = iSpeed;
        Movement = iMovement;
        ennemyType = iType;
    }

    // ----------------------------------------------
    // MoveDown
    // ----------------------------------------------
    // Déplace l'ennemi vers le bas uniquement du cote de sa donnée
    // Le déplacement dans le tableau est géré dans le BoardModel
    // @return True : the ennemy has been moved
    // @return False : the ennemy was unable to move
    public bool MoveDown()
    {
        if (_BlockTimer <= 0 && _MovementTimer > Speed)
        {
            if (tile.Row >= BoardModel.SIZE_ROW - 1)
            {
                PlayerHand playerHand = GameManager.instance.playerHand;
                List<bool> lIsCardPlayable = playerHand.lIsCardPlayable;

                // On bloque la carte de la colonne correspondante à l'ennemie...
                if (lIsCardPlayable[this.tile.Col])
                {
                    playerHand.lPlayerHand[this.tile.Col].dragable = false;
                    playerHand.lPlayerHand[this.tile.Col].gameObject.GetComponent<Image>().color = Color.gray;
                    playerHand.lIsCardPlayable[this.tile.Col] = false;
                }
                // ...sinon on bloque la première qui n'est pas bloquée
                else
                {
                    for (int i = 0; i < lIsCardPlayable.Count; i++)
                    {
                        if (lIsCardPlayable[i])
                        {
                            playerHand.lPlayerHand[i].dragable = false;
                            playerHand.lPlayerHand[i].gameObject.GetComponent<Image>().color = Color.gray;
                            playerHand.lIsCardPlayable[i] = false;
                            break;
                        }
                    }
                }

                tile.ToDestroyFlag = true;
                BoardModel.instance.needDestroy = true;
            }

            // Porté du mouvement random
            int Move = Random.Range(0, Movement + 1);

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

            if (Move > 0 && tile.Row < BoardModel.SIZE_ROW - 1)
            {
                // Si pas d'ennemi sur la case on déplace
                if (BoardModel.instance._Board[tile.Row + Move, tile.Col].tileType != TileType.ENNEMY)
                {
                    tile.Row += Move;
                    BoardModel.instance._NeedRefresh = true;
                    _MovementTimer = 0;
                    return true;
                }
            }

        }
        _MovementTimer += Time.deltaTime;
        _BlockTimer -= Time.deltaTime;
        return false;
    }

    // ----------------------------------------------
    // FreezeMovement
    // ----------------------------------------------
    public void FreezeMovement(float blockTime)
    {
        _BlockTimer = blockTime;
    }
}
