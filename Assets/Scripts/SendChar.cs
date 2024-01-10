using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendChar : MonoBehaviour
{

    public string Function;
    private string text;

    void Start()
    {
        if (Function == "")
        {
            text = gameObject.name;
        }
        else{
            text = Function;
        }

    }

    public void trigger(){
        GameObject.Find("NoteTool").SendMessage("UpdateString", text);
        //Debug.Log(text);
    }
}