using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionModuleConnector : MonoBehaviour
{
    public GameObject button;
    public GameObject[] instruction;
    //public GameObject nextButton;
    //public GameObject prevButton;
    public GameObject parentObject;
    public GameObject[] moduleButtons; //module buttons list, must have all buttons for each button with script
    public GameObject canvas;
    //public GameObject intro;
    //public bool buttonAvail;
    //public GameObject help;
    public bool buttonActive; //bool to check if the current button is active in scene, and should be interactable or not
    public int index; //index keeps track of which set up instructions the button is on currently

    //instructions board text
    //public Text instructionBoard;

    public bool isIntroduction = false; //make sure introduction is played before moving on to new buttons
    public GameObject introduction; //this object must be active to make isIntroduction false (ready to move on)
                                    // Start is called before the first frame update


    public Text moduleText; //text for calculator
    void Start()
    {
        
        button = this.gameObject;
        if (button.name.Equals("InstructionsButton"))
            this.buttonActive = true;
        //introduction = GameObject.Find("InstructionGeneralFinal");
        //buttonAvail = true;
        //intro = GameObject.Find("InstructionGeneral");
        //intro.SetActive(true);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonActive == false)
        {
            for (int i = 0; i < instruction.Length - 1; i++)
            {
                instruction[i].SetActive(false);
            }
        }
        
        //if (introduction.activeInHierarchy)
        //{
        //    isIntroduction = false;
        //}
        
    }

    public void TriggerButton(){
        parentObject.GetComponent<Image>().color = Color.cyan;
        print("we got to the trigger");
        print("canvas child: " + canvas.transform.childCount);
        if (true)//(isIntroduction == false) //other.name.Equals("finger_index_2_r") && isIntroduction == false)
        {
            for (int i = 0; i < canvas.transform.childCount; ++i)
            {
                print("children:" + canvas.transform.GetChild(i).gameObject.name);
                canvas.transform.GetChild(i).gameObject.SetActive(false); // or false
            }
            for (int i = 0; i < moduleButtons.Length; i++)
            {
                print("button bool before: " + moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive);
                moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive = false;
                print("button bool after: " + moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive);

            }
            this.buttonActive = true;
            //instructionBoard.text = parentObject.name.ToString();
            print("name: " + instruction[0].name);
            instruction[0].SetActive(true);
            moduleText.text = "Module: " + this.name;
            index = 0;
        }
        Invoke("MakeAvail", 0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        parentObject.GetComponent<Image>().color = Color.cyan;
        print("we got to the trigger");
        print("canvas child: " + canvas.transform.childCount);
        if (true)//(isIntroduction == false) //other.name.Equals("finger_index_2_r") && isIntroduction == false)
        {
            for (int i = 0; i < canvas.transform.childCount; ++i)
            {
                print("children:" + canvas.transform.GetChild(i).gameObject.name);
                canvas.transform.GetChild(i).gameObject.SetActive(false); // or false
            }
            for (int i = 0; i < moduleButtons.Length; i++)
            {
                print("button bool before: " + moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive);
                moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive = false;
                print("button bool after: " + moduleButtons[i].GetComponent<InstructionModuleConnector>().buttonActive);

            }
            this.buttonActive = true;
            //instructionBoard.text = parentObject.name.ToString();
            print("name: " + instruction[0].name);
            instruction[0].SetActive(true);
            moduleText.text = "Module: " + this.name;
            index = 0;
        }
        Invoke("MakeAvail", 0.5f);
    }

    void MakeAvail()
    {
        //buttonAvail = true;
        parentObject.GetComponent<Image>().color = Color.white;
    }

    public void Prev()
    {
        if (buttonActive)
        {
            if(index >= 1)
            {

                instruction[index].SetActive(false);
                index--;
                instruction[index].SetActive(true);
            }
        }
    }

    public void Next()
    {
        if (buttonActive)
        {
            if (index < instruction.Length-1)
            {

                instruction[index].SetActive(false);
                index++;
                instruction[index].SetActive(true);
            }
        }
    }

    
}
