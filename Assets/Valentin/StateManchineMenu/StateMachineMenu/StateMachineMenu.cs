using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    MAINMENU,
    JOUER,
    SCORE,
    OPTIONS,
    FIN,
}

public class StateMachineMenu : MonoBehaviour
{
    public State state;
    public GameObject guiMainMenu;
    public GameObject guiJouer;
    public GameObject guiScore;
    public GameObject guiOptions;
    public GameObject guiFin;

    static public StateMachineMenu instance; //singleton

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.isGameOver)
        {
            state = State.FIN;
        }
        //state = State.MAINMENU;
    }

    // Update is called once per frame
    void Update()
    {
        guiMainMenu.SetActive(state == State.MAINMENU);
        guiJouer.SetActive(state == State.JOUER);
        guiScore.SetActive(state == State.SCORE);
        guiOptions.SetActive(state == State.OPTIONS);
        guiFin.SetActive(state == State.FIN);
    }

    public void SetState(State newState)
    {
        state = newState;
    }

    //Jeu
    public void OnClickPlay() 
    {
        SetState(State.JOUER);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Score
    public void OnClickScore()
    {
        SetState(State.SCORE);
    }

    //Paramètres
    public void OnClickSettings()
    {
        SetState(State.OPTIONS);
    }

    //Retour Menu
    public void OnClickBackMenu()
    {
        SetState(State.MAINMENU);
    }

    //Quitter l'application
    public void OnClickQuit()
    {
        Application.Quit();
    }

}
