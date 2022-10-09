using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    private GameManager gameManager;
    void Start()
    {
        if (GameManager.isGameOver && textMesh != null)
        {
            textMesh.text = GameManager.gameTimer.ToString("0.00") + " s";
            HighScoreTableV2.instance.Record("Test", GameManager.gameTimer);
            HighScoreTableV2.instance.Scores();
        }
    }
}
