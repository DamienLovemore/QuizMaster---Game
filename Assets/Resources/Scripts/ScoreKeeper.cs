using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int correctAnswears = 0;
    private int questionsSeen = 0;

    //Gets the numbers of answears the player answered
    //correctly so far
    public int GetCorrectAnswears()
    {
        int returnValue;

        returnValue = correctAnswears;

        return returnValue;
    }

    //Increases the count of answears that the player
    //answered correctly so far
    public void IncrementCorrectAnswears()
    {
        correctAnswears++;
    }

    //Gets the number of answears that the player has seen
    public int GetQuestionsSeen()
    {
        int returnValue;

        returnValue = questionsSeen;

        return returnValue;
    }

    //Increases the count of answears that the player has seen
    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        int percentageCorrectAnswears;

        percentageCorrectAnswears = Mathf.RoundToInt((float)correctAnswears * 100 / (float)questionsSeen);

        return percentageCorrectAnswears;
    }
}
