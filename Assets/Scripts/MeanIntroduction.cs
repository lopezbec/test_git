using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeanIntroduction : MonoBehaviour
{
    //keeps track of the stage the level introduction script is at. basic state machine.
    public int State = 0; //originally 0
    public int TutorialState = 0;

    public GameObject MeanEquation;

    public GameObject Tutorial;
    public GameObject DrillDisplay;
    public Image bg;
    public Text TutorialText;
    GameObject drill; //ingame instantiation of the drill prefab

    GameObject equation; //ingame instantiation of the mean equation prefab
    GameObject tut; //ingame instantiation of text tutorial of tools
    GameObject temp; //gets the entire object of cube
    BoxCollider currentCollider; //gets the specific box collider from a cube

    void Start()
    {
        bg.enabled = false;
        //TutorialText = Tutorial.GetComponent<Text>();
        Tutorial.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        Tutorial.GetComponent<Canvas>().planeDistance = 1.5f;

        temp = GameObject.Find("WT Collider 1");
        temp.GetComponent<Behaviour>().enabled = true;
        currentCollider = temp.GetComponent<BoxCollider>();

        State++;
    }

    void Update()
    {
        if (State == 1)
        {
            bg.enabled = true;
            DrillDemo();
            TutorialText.text = "Walk over to the blue glow.\n Enter the glow to dismiss this message and examine the drill, \n" +
                " then Press A to start the lesson";
            temp.SetActive(true);
        }
        else if (State == 2 && OVRInput.GetDown(OVRInput.Button.One))
        {
            TutorialText.text = "This is the ARITHMETIC MEAN lesson\n" +
                    "Your goal is to do a time study to determine the average time\n" + "it takes a drill to be assembled\n\n" +
                    "You will be able to proceed in the introduction by\n" + "following the blue glowing areas on the ground\n" +
                    "\nPress A to continue";
            State++;
        }
        else if (State == 3 && OVRInput.GetDown(OVRInput.Button.One))
        {
            TutorialText.text = "The tools available to you are a calculator, a notebook, a stopwatch, and a graph.\n" +
                    "These tools are available at the table, which now has a blue glow in front of it.\n\n" +
                    "When you think you have an answer, submit it to the board behind the table.\n" +
                    "Before beginning, please take a moment to review the equation for arithmatic mean." +
                    "\nPress A to continue";
            State++;

            temp.GetComponent<Behaviour>().enabled = false;
            temp = GameObject.Find("WT Collider 2");
            temp.GetComponent<Behaviour>().enabled = true;
            currentCollider = temp.GetComponent<BoxCollider>();
        }
        else if (State == 4 && OVRInput.GetDown(OVRInput.Button.One))
        {
            Tutorial.gameObject.SetActive(false);

            MeanDemo();
        }
        else if (State == 5 && OVRInput.GetDown(OVRInput.Button.One))
        {
            Tutorial.gameObject.SetActive(true);
            TutorialText.text = "Now you can begin recording data.\n" +
                "Walk over to the blue glow next to the conveyor belt to begin producing drills";
            State++;

            temp.GetComponent<Behaviour>().enabled = false;
            temp = GameObject.Find("WT Collider 3");
            temp.GetComponent<Behaviour>().enabled = true;
            currentCollider = temp.GetComponent<BoxCollider>();
        }
        else if (State == 6 && OVRInput.GetDown(OVRInput.Button.One))
        {
            Destroy(Tutorial);
            Tutorial = null;
            GameObject.Find("Master").SendMessage("Active");
            State++;
        }
        else { }

    }


    void MeanDemo()
    {
        if (equation == null)
        {
            equation = Instantiate(MeanEquation); //instantiates the mean equation demo
            equation.GetComponent<Animator>().SetTrigger("Start"); //starts the animation
            Canvas canvas = equation.GetComponentInChildren<Canvas>();
            canvas.worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>(); //orients the canvas onto the camera
            canvas.planeDistance = 1.5f;
        }

        if (OVRInput.GetDown(OVRInput.Button.One)) //mean demo is done being used
        {
            State++;
            TutorialState++;
            Destroy(equation);
            equation = null;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        { //give the student a chance to restart the equation demo
            equation.GetComponent<Animator>().SetTrigger("Start");
        }
    }



    void DrillDemo()
    {
        if (drill == null) //creates the model in the game world and properly positions it
        {
            drill = Instantiate(DrillDisplay);
            drill.transform.position = new Vector3(33, 1.2f, -13);
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            State++;
            TutorialState++;
            Destroy(drill); //drill display is done being used
            drill = null;
        }
    }

}


