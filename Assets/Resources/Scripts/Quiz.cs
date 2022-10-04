using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    //Separate variables of the script in sections with these headers
    //To make it more easy to understand when there is a lot of
    //variables.
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private List<QuestionSO> questions = new List<QuestionSO>();
    private QuestionSO currentQuestion;

    [Header("Answears")]
    [SerializeField] private GameObject[] answearButtons;
    private int correctAnswearIndex;
    private bool hasAnsweredEarly;

    [Header("Buttons Color")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;
    private Timer timerHandler;

    // Start is called before the first frame update
    void Start()
    {
        timerHandler = FindObjectOfType<Timer>();
    }

    void Update()
    {
        //Gets the amount to fill the timer fraction (between 0 and 1)
        timerImage.fillAmount = timerHandler.GetTimerFillFraction();
        if(timerHandler.isTimeShowNextQuestion())
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timerHandler.SetTimeShowNextQuestion(false);
        }
        //Ifs the timer to answer the question has run out, and the player
        //did not answear in time.
        else if ((!hasAnsweredEarly) && (!timerHandler.isAnswearingQuestion()))
        {
            //Pass an index that does not exist to automacally fall into
            //the answeared incorrectly if block
            DisplayAnswear(-1);
            SetButtonState(false);
        }
    }

    private void DisplayAnswear(int index)
    {
        //Correct Answear
        if (index == currentQuestion.GetCorrectAnswearIndex())
        {
            questionText.text = "Correct!";
            //Acces the component that holds the image of this button
            Image buttonImage = answearButtons[index].GetComponent<Image>();
            //Alter the source image of this button to the one the correct
            //answear
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            //Gets the correct answear index for this question
            correctAnswearIndex = currentQuestion.GetCorrectAnswearIndex();

            //Gets the correct answear text
            string answear = currentQuestion.GetAnswear(correctAnswearIndex);
            questionText.text = $"Sorry,the correct answear was:\n {answear}";
            Image buttonImage = answearButtons[correctAnswearIndex].GetComponent<Image>();
            //Alter the source image of this button to the one the correct
            //answear
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    //Event triggered when the player press a answear button
    public void OnAnswearSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswear(index);
        //After the question has been answered, all the buttons
        //should be disabled
        SetButtonState(false);
        //And the timer should stop
        timerHandler.CancelTimer();
    }

    //Swaps the current answear to the next one
    private void GetNextQuestion()
    {
        //Starts the next question only if there is at least one
        //question reamining
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonsSprites();
            GetRandomQuestion();
            DisplayQuestionInfos();
        }        
    }

    //Gets a random question to be used for the next currentQuestion
    private void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];

        //Checks before removing to avoid erros, as the questions is
        //used by others scripts
        if (questions.Contains(currentQuestion))
            //Removes the question to avoid sorting the same question twice
            questions.Remove(currentQuestion);
    }

    //Display the text of the current question, and its
    //possible answears in the correct elements
    private void DisplayQuestionInfos()
    {
        //Set the text of this question in the UI
        questionText.text = currentQuestion.GetQuestionText();

        //Update the text of the answear buttons to be of the possible answear
        //for this QuestionSO
        for (int buttonIndex = 0; buttonIndex < answearButtons.Length; buttonIndex++)
        {
            TextMeshProUGUI buttonText = answearButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswear(buttonIndex);
        }
    }

    //Sets the button editable state
    private void SetButtonState(bool state)
    {
        for(int buttonIndex = 0; buttonIndex < answearButtons.Length; buttonIndex++)
        {
            //Gets the button to be edited
            Button targetButton = answearButtons[buttonIndex].GetComponent<Button>();
            //Alter is editable state
            targetButton.interactable = state;
        }
    }

    //Swaps the sprite used for the answears button to be the default
    //answear sprite
    private void SetDefaultButtonsSprites()
    {
        for(int buttonIndex = 0; buttonIndex < answearButtons.Length; buttonIndex++)
        {
            //Gets the image(holds its sprite and its configuration)
            //component of this button
            Image buttonImage = answearButtons[buttonIndex].GetComponentInChildren<Image>();
            //Alter the source image of this button to the default
            //one
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
