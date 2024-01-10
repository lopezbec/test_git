using UnityEngine;
using UnityEngine.UI;
using System;


public class ChalkManager : MonoBehaviour
{
    public Text providedAnswer;
    public Text correctanswer;
    private double correctAnswer;
    public static int levelSelection;


    void Start()
    {
        //providedAnswer = GameObject.Find("SubmittedAnswer").GetComponent<Text>();
    }
  
    public void check()
    { //called every time the user hits the enter key. Currently only capable of checking floating point values.
        correctAnswer = GraphManager.solution;
        print("correct answer: " + correctAnswer);
        if ((float.Parse(providedAnswer.text) < correctAnswer * 1.05) && (float.Parse(providedAnswer.text) > correctAnswer * 0.95))
        {
            string correctAnswerStr = string.Format("{0:0.00}", Math.Truncate(correctAnswer * 100) / 100);
            correctanswer.text = "Correct!\n" + correctAnswerStr;
            //GameObject.Find("CorrectAnswer").GetComponent<Text>().text = "Correct!\n" + correctAnswerStr;
        }
        else
        {
            correctanswer.text = "Incorrect";
            //GameObject.Find("CorrectAnswer").GetComponent<Text>().text = "Incorrect";
        }
    }

    public void UpdateString(string str)
    {
        string updatedtext;
        //Debug.Log(str);
        if (str == "[space]")
        {
            updatedtext = providedAnswer.text + " ";
            providedAnswer.text = updatedtext;
        }

        else if (str == "DEL")
        {
            if (providedAnswer.text.Length > 0)
                providedAnswer.text = providedAnswer.text.Substring(0, providedAnswer.text.Length - 1); //deletes the last character by reassigning to the substring of itself -1
        }

        else if (str == "ENTER")
        {
            check();
        }
        else
        {
            updatedtext = providedAnswer.text + str;
            providedAnswer.text = updatedtext;
        }

    }
    void Update()
    {

    }
}