using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable objects are objects that don`t need to be attached to game objects.
//(Commonly used to store information data;CreateAssetMenu is used to display a
//Scritable object in the create list)
[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    //Makes the string to edited with more than one line, and with scrollable
    //actions
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter new question text here";
    [SerializeField] private string[] answears = new string[4];
    [SerializeField] private int correctAnswearIndex;

    //Returns the text of this question
    public string GetQuestionText()
    {
        string returnValue;

        returnValue = question;

        return returnValue;
    }

    //Returns the correct answear index for this question
    public int GetCorrectAnswearIndex()
    {
        int returnValue;

        returnValue = correctAnswearIndex;

        return returnValue;
    }

    //Returns the text associated with a answear of this index
    public string GetAnswear(int index)
    {
        string returnValue;

        returnValue = answears[index];

        return returnValue;
    }
}
