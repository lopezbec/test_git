using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightHandButtons : MonoBehaviour
{
    public InputAction aButton;
    public InputAction bButton;
    public GameObject prevObj;
    public GameObject nextObj;
    // Start is called before the first frame update
    void Start()
    {
        aButton.Enable();
        bButton.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(aButton.IsPressed()){
            print("A pressed");
            nextObj.GetComponent<Prev_Next_Controller>().TriggerButton();
        }
        if(bButton.IsPressed()){
            print("B pressed");
            prevObj.GetComponent<Prev_Next_Controller>().TriggerButton();
        }
    }
}
