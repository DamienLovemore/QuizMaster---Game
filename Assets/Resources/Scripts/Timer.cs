using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswear = 30f;
    [SerializeField] float timeShowCorrectAnswear = 10f;
    private bool isAnswearing = false;
    private float fillFraction;
    private float timerValue;
    private bool loadNextQuestion = false;

    void Update()
    {
        UpdateTimer();
    }

    //Interrupts the timer to jump it to finished
    public void CancelTimer()
    {
        timerValue = 0;
    }

    //Updates the timer value every frame
    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnswearing)
        {
            if (timerValue > 0)
            {
                //Returns a fraction between 0 and 1
                fillFraction = timerValue / timeToAnswear;
            }
            //Switches from answearing to show correct answear mode
            else
            {                
                timerValue = timeShowCorrectAnswear;
                isAnswearing = false;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeShowCorrectAnswear;
            }
            //Switches from showing answear to answear mode
            else
            {                
                timerValue = timeToAnswear;
                isAnswearing = true;
                loadNextQuestion = true;
            }
        }
    }

    //Gets if it is answearing the question or not
    public bool isAnswearingQuestion()
    {
        bool returnValue;

        returnValue = isAnswearing;

        return returnValue;
    }

    //Gets if it is time to show the next question
    //(After question time has passed, and showing
    //answear time has passed)
    public bool isTimeShowNextQuestion()
    {
        bool returnValue;

        returnValue = loadNextQuestion;

        return returnValue;
    }

    //Is used to set the value of the next question
    //back to false, if the next question has been
    //loaded
    public void SetTimeShowNextQuestion(bool value)
    {
        loadNextQuestion = value;
    }

    //Gets the current amount of remaining time
    public float GetRemainingTime()
    {
        float returnValue;

        returnValue = timerValue;

        return returnValue;
    }

    //Gets the fraction that is currently set
    //for the timer
    public float GetTimerFillFraction()
    {
        float returnValue;

        returnValue = fillFraction;

        return returnValue;
    }
}
