using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Quiz quizManager;
    private EndScreen endScreenManager;

    void Awake()
    {
        quizManager = FindObjectOfType<Quiz>();
        endScreenManager = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        //In the beggining of the game, the game canvas should be visible,
        //and the end canvas should be hidden
        quizManager.gameObject.SetActive(true);
        //Gets the game object that is attached to this script, and change
        //its active state (visibilty and response of the object)
        endScreenManager.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quizManager.isGameCompleted())
        {
            quizManager.gameObject.SetActive(false);
            endScreenManager.gameObject.SetActive(true);
            endScreenManager.ShowFinalScore();
        }
    }

    //Restart the game for the player to play again
    public void OnReplayLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
