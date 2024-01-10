using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorButton : MonoBehaviour
{
    public bool Calculator;
    public bool Submission;
    public GameObject Add;
    public GameObject Subtract;
    public GameObject Divide;
    public GameObject Multiply;
    public GameObject Equal;
    public GameObject Enter;
    public GameObject Clear;
    public GameObject SubmitButton;
    public GameObject CalcButton;
    public GameObject CorrectText;
    public GameObject YourText;
    public GameObject Equations;
    public GameObject sqaure;
    public GameObject sqrt;
    public GameObject log;

    public static bool calc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerButton()
    {
        if (Calculator == true)
        {
            calc = true;
            Add.SetActive(true);
            Subtract.SetActive(true);
            Divide.SetActive(true);
            Multiply.SetActive(true);
            Equal.SetActive(true);
            Clear.SetActive(true);
            Equations.SetActive(true);
            SubmitButton.SetActive(true);
            CalcButton.SetActive(false);
            YourText.SetActive(false);
            CorrectText.SetActive(false);
            Enter.SetActive(false);

            sqaure.SetActive(true);
            sqrt.SetActive(true);
            log.SetActive(true);

        }

        if (Submission == true)
        {
            calc = false;
            Add.SetActive(false);
            Subtract.SetActive(false);
            Divide.SetActive(false);
            Multiply.SetActive(false);
            Equal.SetActive(false);
            Clear.SetActive(false);
            Equations.SetActive(false);
            SubmitButton.SetActive(false);
            CalcButton.SetActive(true);
            YourText.SetActive(true);
            CorrectText.SetActive(true);
            Enter.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Calculator == true)
        {
            calc = true;
            Add.SetActive(true);
            Subtract.SetActive(true);
            Divide.SetActive(true);
            Multiply.SetActive(true);
            Equal.SetActive(true);
            Clear.SetActive(true);
            Equations.SetActive(true);
            SubmitButton.SetActive(true);
            CalcButton.SetActive(false);
            YourText.SetActive(false);
            CorrectText.SetActive(false);
            Enter.SetActive(false);

            sqaure.SetActive(true);
            sqrt.SetActive(true);
            log.SetActive(true);

        }

        if (Submission == true)
        {
            calc = false;
            Add.SetActive(false);
            Subtract.SetActive(false);
            Divide.SetActive(false);
            Multiply.SetActive(false);
            Equal.SetActive(false);
            Clear.SetActive(false);
            Equations.SetActive(false);
            SubmitButton.SetActive(false);
            CalcButton.SetActive(true);
            YourText.SetActive(true);
            CorrectText.SetActive(true);
            Enter.SetActive(true);
        }
    }
}
