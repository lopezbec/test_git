using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCharCalc : MonoBehaviour
{

    //public string Function;
    //private string text;

    public GameObject target;
    public bool zero;
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    public bool five;
    public bool six;
    public bool seven;
    public bool eight;
    public bool nine;
    public bool deci;
    public bool enter;
    public bool delete;
    public bool clear;

    public bool subtract;
    public bool add;
    public bool divide;
    public bool multiply;
    public bool sqaure;
    public bool sqrt;
    public bool log;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(EnableAfterDelay(other));
        other.enabled = false;
        if (true)
        {
            if (CalculatorButton.calc == true)
            {
                if (zero == true)
                {
                    target.SendMessage("UpdateString", "0");
                }
                if (one == true)
                {
                    target.SendMessage("UpdateString", "1");
                }
                if (two == true)
                {
                    target.SendMessage("UpdateString", "2");
                }
                if (three == true)
                {
                    target.SendMessage("UpdateString", "3");
                }
                if (four == true)
                {
                    target.SendMessage("UpdateString", "4");
                }
                if (five == true)
                {
                    target.SendMessage("UpdateString", "5");
                }
                if (six == true)
                {
                    target.SendMessage("UpdateString", "6");
                }
                if (seven == true)
                {
                    target.SendMessage("UpdateString", "7");
                }
                if (eight == true)
                {
                    target.SendMessage("UpdateString", "8");
                }
                if (nine == true)
                {
                    target.SendMessage("UpdateString", "9");
                }
                if (deci == true)
                {
                    target.SendMessage("UpdateString", ".");
                }
                if (enter == true)
                {
                    target.SendMessage("UpdateString", "[enter]");
                }
                if (delete == true)
                {
                    target.SendMessage("UpdateString", "[backspace]");
                }
                if (clear == true)
                {
                    target.SendMessage("UpdateString", "[clear]");
                }

                if (subtract == true)
                {
                    target.SendMessage("UpdateString", "-");
                }
                if (add == true)
                {
                    target.SendMessage("UpdateString", "+");
                }
                if (multiply == true)
                {
                    target.SendMessage("UpdateString", "*");
                }
                if (divide == true)
                {
                    target.SendMessage("UpdateString", "/");
                }
                if (sqaure == true)
                {
                    string temp = target.GetComponent<CalculatorManager>().newestNumber;
                    target.SendMessage("UpdateString", "*");
                    target.SendMessage("UpdateString", temp);
                }
                if (sqrt == true)
                {
                    target.SendMessage("UpdateString", "#");
                }
                if (log == true)
                {
                    target.SendMessage("UpdateString", "l");
                }
            }
        }
    }

    public void TriggerButton()
    {
        
        
        if (CalculatorButton.calc == true)
        {
            if (zero == true)
            {
                target.SendMessage("UpdateString", "0");
            }
            if (one == true)
            {
                target.SendMessage("UpdateString", "1");
            }
            if (two == true)
            {
                target.SendMessage("UpdateString", "2");
            }
            if (three == true)
            {
                target.SendMessage("UpdateString", "3");
            }
            if (four == true)
            {
                target.SendMessage("UpdateString", "4");
            }
            if (five == true)
            {
                target.SendMessage("UpdateString", "5");
            }
            if (six == true)
            {
                target.SendMessage("UpdateString", "6");
            }
            if (seven == true)
            {
                target.SendMessage("UpdateString", "7");
            }
            if (eight == true)
            {
                target.SendMessage("UpdateString", "8");
            }
            if (nine == true)
            {
                target.SendMessage("UpdateString", "9");
            }
            if (deci == true)
            {
                target.SendMessage("UpdateString", ".");
            }
            if (enter == true)
            {
                target.SendMessage("UpdateString", "[enter]");
            }
            if (delete == true)
            {
                target.SendMessage("UpdateString", "[backspace]");
            }
            if (clear == true)
            {
                target.SendMessage("UpdateString", "[clear]");
            }

            if (subtract == true)
            {
                target.SendMessage("UpdateString", "-");
            }
            if (add == true)
            {
                target.SendMessage("UpdateString", "+");
            }
            if (multiply == true)
            {
                target.SendMessage("UpdateString", "*");
            }
            if (divide == true)
            {
                target.SendMessage("UpdateString", "/");
            }
            if (sqaure == true)
            {
                string temp = target.GetComponent<CalculatorManager>().newestNumber;
                target.SendMessage("UpdateString", "*");
                target.SendMessage("UpdateString", temp);
            }
            if (sqrt == true)
            {
                target.SendMessage("UpdateString", "#");
            }
            if (log == true)
            {
                target.SendMessage("UpdateString", "l");
            }
            
        }
    }
    IEnumerator EnableAfterDelay(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.enabled = true;


    }
    //public void trigger()
    //{
    //GameObject.Find("CalculatorTool").SendMessage("UpdateString", text);
    //Debug.Log(text);
    //}
}

