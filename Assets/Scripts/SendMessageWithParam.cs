////////////////////////////////////////////////////////////////////////
// SendMessageWithParam.cs
// By Don Hopkins.
// Copyright (C) 2013 by Pantomime Corporation.
// You are free to use and modify this, under the BSD license.

//modified by Brad Nulsen, 2019

////////////////////////////////////////////////////////////////////////


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////////////////////////////////////////////


/*This script can be attached to a slider in order to send its current value to any target functions on any object
 *A receiving function that handles the value must be created for the respective object.
 */
public class SendMessageWithParam : MonoBehaviour
{


   


    public List<GameObject> Targets; //Use Unity editor to identify target objects
    public List<String> Messages; //Names of the functions to be called by the corresponding target object sharing this string's index


    //initializes all targets to have the same starting value as the actual slider
    public void Start() {
        int i = 0;
        for (i = 0; i < Targets.Count; i++)
        {
            float Value = gameObject.GetComponent<Slider>().value;
            Targets[i].SendMessage(Messages[i], Value);
        }
    }

    //call this every time the value of the slider changes
    public void TriggerSendMessage()
    {
        int i = 0;
        for (i = 0; i < Targets.Count; i++){
            float Value = gameObject.GetComponent<Slider>().value;
            Targets[i].SendMessage(Messages[i], Value);
        }
    }


}


