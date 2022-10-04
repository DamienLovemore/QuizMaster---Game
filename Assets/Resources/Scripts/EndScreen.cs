using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    private ScoreKeeper scoreHandler;

    void Awake()
    {
        scoreHandler = FindObjectOfType<ScoreKeeper>();
    }

    //Functions responsible for showing the final result of the player
    public void ShowFinalScore()
    {
        string finalScore;

        finalScore = "Congratulations!\nYou got a score of " + scoreHandler.CalculateScore();

        finalScoreText.text = finalScore;
    }
}
