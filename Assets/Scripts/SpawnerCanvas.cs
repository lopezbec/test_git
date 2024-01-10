using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnerCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject spawnerObject;
    //public GameObject[] conveyer;
    public GameObject parentObject; //for changing image to show input
    public Text text;
    public bool buttonAvail; //prevents button from being pressed in rapid succession
    void Start()
    {
        button = this.gameObject;
        buttonAvail = true;
        if (button.name.Equals("Up_Button_Parts"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();
        }

        if (button.name.Equals("Down_Button_Parts"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();

        }

        if (button.name.Equals("Up_Defect_Chance"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();

        }

        if (button.name.Equals("Down_Defect_Chance"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();
        }


        if (button.name.Equals("Up_Production_Rate"))
        {
            //print(button.name);
            text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

        }

        if (button.name.Equals("Down_Production_Rate"))
        {
            //print(button.name);            
            text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (button.name.Equals("Up_Button_Parts"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();
        }

        if (button.name.Equals("Down_Button_Parts"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();

        }

        if (button.name.Equals("Up_Defect_Chance"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();

        }

        if (button.name.Equals("Down_Defect_Chance"))
        {
            //print(button.name);
            text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();
        }


        if (button.name.Equals("Up_Production_Rate"))
        {
            //print(button.name);
            text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

        }

        if (button.name.Equals("Down_Production_Rate"))
        {
            //print(button.name);            
            text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //change color on trigger as well as stop from letting buttons
        //be pressed in general until color changes back

        parentObject.GetComponent<Image>().color = Color.cyan;
        //print("trigger achieved");
        if (buttonAvail)
        {
            buttonAvail = false;
            //print("finger is inside trigger");
            if (button.name.Equals("Up_Button_Parts"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreasePartSpawn();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();
            }

            if (button.name.Equals("Down_Button_Parts"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreasePartSpawn();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();

            }

            if (button.name.Equals("Up_Defect_Chance"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreaseDefectChance();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();

            }

            if (button.name.Equals("Down_Defect_Chance"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreaseDefectChance();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();
            }
           
            if (button.name.Equals("Up_Speed_Robot"))
            {
                
                //print(button.name);
                Animator anim = spawnerObject.GetComponent<Animator>();
                if(anim.speed < 5)
                {
                    anim.speed += 1;
                    text.GetComponent<Text>().text = "Robot Arm Speed: " + anim.speed;
                    //print("THIS IS THE UP SPEED: " + text.GetComponent<Text>().text);
                }
                

            }

            if (button.name.Equals("Down_Speed_Robot"))
            {
                //print(button.name);
                Animator anim = spawnerObject.GetComponent<Animator>();
                if(anim.speed > 1)
                {
                    anim.speed -= 1;
                    text.GetComponent<Text>().text = "Robot Arm Speed: " + anim.speed;
                }
                
            }

            if (button.name.Equals("Up_Production_Rate"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreaseProductionRate();
                text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

            }

            if (button.name.Equals("Down_Production_Rate"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreaseProductionRate();
                text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

            }
        }

        Invoke("MakeAvail", 0.5f);
        
    }

    public void TriggerButton()
    {
        parentObject.GetComponent<Image>().color = Color.cyan;
        //print("trigger achieved");
        if (buttonAvail)
        {
            buttonAvail = false;
            //print("finger is inside trigger");
            if (button.name.Equals("Up_Button_Parts"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreasePartSpawn();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();
            }

            if (button.name.Equals("Down_Button_Parts"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreasePartSpawn();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getNumParts();

            }

            if (button.name.Equals("Up_Defect_Chance"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreaseDefectChance();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();

            }

            if (button.name.Equals("Down_Defect_Chance"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreaseDefectChance();
                text.GetComponent<UnityEngine.UI.Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getDefectChance();
            }

            if (button.name.Equals("Up_Speed_Robot"))
            {

                //print(button.name);
                Animator anim = spawnerObject.GetComponent<Animator>();
                if (anim.speed < 5)
                {
                    anim.speed += 1;
                    text.GetComponent<Text>().text = "Robot Arm Speed: " + anim.speed;
                    //print("THIS IS THE UP SPEED: " + text.GetComponent<Text>().text);
                }


            }

            if (button.name.Equals("Down_Speed_Robot"))
            {
                //print(button.name);
                Animator anim = spawnerObject.GetComponent<Animator>();
                if (anim.speed > 1)
                {
                    anim.speed -= 1;
                    text.GetComponent<Text>().text = "Robot Arm Speed: " + anim.speed;
                }

            }

            if (button.name.Equals("Up_Production_Rate"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().IncreaseProductionRate();
                text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

            }

            if (button.name.Equals("Down_Production_Rate"))
            {
                //print(button.name);
                spawnerObject.GetComponent<BasicSpawner>().DecreaseProductionRate();
                text.GetComponent<Text>().text = "" + spawnerObject.GetComponent<BasicSpawner>().getPruductionRate();

            }
        }

        Invoke("MakeAvail", 0.5f);
    }
    void MakeAvail()
    {
        buttonAvail = true;
        parentObject.GetComponent<Image>().color = Color.white;

    }
}