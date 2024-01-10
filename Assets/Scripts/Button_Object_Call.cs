using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is a script that is generically calling objects based on button presses
Use the public variables to determine which items should be activated
*/

public class Button_Object_Call : MonoBehaviour
{
    public GameObject activatedObj;


    public void Activate()
    {
        activatedObj.gameObject.SetActive(true);
    }
}
