using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prev_Next_Controller : MonoBehaviour
{
    public GameObject button;
    public GameObject[] moduleButtons;
    
    public GameObject parentObject;

    public bool controller_make_avail;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
        controller_make_avail = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(controller_make_avail == true)
        {
            parentObject.GetComponent<Image>().color = Color.cyan;
            controller_make_avail = false;
            if (button.name.Equals("Next_Button"))
            {
                for (int i = 0; i < moduleButtons.Length; i++)
                {
                    moduleButtons[i].GetComponent<InstructionModuleConnector>().Next();
                }
            }
            if (button.name.Equals("Prev_Button"))
            {
                for (int i = 0; i < moduleButtons.Length; i++)
                {
                    moduleButtons[i].GetComponent<InstructionModuleConnector>().Prev();
                }
            }
            
        }
        Invoke("MakeAvail", 0.5f);
    }

    public void TriggerButton(){
        print("we got here! for button pressing!");
        if(controller_make_avail == true)
        {
            parentObject.GetComponent<Image>().color = Color.cyan;
            controller_make_avail = false;
            if (button.name.Equals("Next_Button"))
            {
                for (int i = 0; i < moduleButtons.Length; i++)
                {
                    moduleButtons[i].GetComponent<InstructionModuleConnector>().Next();
                }
            }
            if (button.name.Equals("Prev_Button"))
            {
                for (int i = 0; i < moduleButtons.Length; i++)
                {
                    moduleButtons[i].GetComponent<InstructionModuleConnector>().Prev();
                }
            }
            
        }
        Invoke("MakeAvail", 0.3f);
    }

    void MakeAvail()
    {
        //buttonAvail = true;
        parentObject.GetComponent<Image>().color = Color.white;
        controller_make_avail = true;
    }

}
