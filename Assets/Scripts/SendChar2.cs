using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendChar2 : MonoBehaviour
{

    //this function is attached to a button on the UI keyboard for use in the chalkboard object
    //to make a custom version of this, replace the line of code in the trigger() function with "trigger.SendMessage("<function that handles incoming strings>", text);
    //just make sure to provide a target in the editor if you do so
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

    void Start()
    {
        /*if (Function == "") //if you dont provide an explicit value for this key, the name of the object is the string that is sent to the UI text object
        {
            text = gameObject.name;
        }
        else{
            text = Function;
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            if (CalculatorButton.calc == false)
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
                    target.SendMessage("UpdateString", "ENTER");
                }
                if (delete == true)
                {
                    target.SendMessage("UpdateString", "DEL");
                }
            }
        }
    }
    public void TriggerButton()
    {
        if (CalculatorButton.calc == false)
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
                target.SendMessage("UpdateString", "ENTER");
            }
            if (delete == true)
            {
                target.SendMessage("UpdateString", "DEL");
            }
        }
    }
        /*public void trigger(){ //to configure the button, 
            GameObject.Find("ChalkBoard").SendMessage("UpdateString", text);

        }*/
    }