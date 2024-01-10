using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {

    //This script simply gives easy access to create a dynamic unit label

    public string Label; //constant appended to the end of the text (i.e. "seconds" or "speed"

    //this function is called elsewhere such as the SendMessageWithParam script,
    // will receive a value and update the text to be "<value> <label>"
    public void UpdateString(float text){
        gameObject.GetComponent<Text>().text = text.ToString() + " " + Label;
    }
}
