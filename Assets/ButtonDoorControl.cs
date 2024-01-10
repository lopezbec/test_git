using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoorControl : MonoBehaviour
{
    public Animator myDoor;
    // Start is called before the first frame update
    public void ButtonDoorDown()
    {
        myDoor.Play("ButtonDoor", 0, 0.0f);
        Debug.Log("Button Pressed");
    }
}
