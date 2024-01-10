using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MedianIntroduction : MonoBehaviour
{
    //keeps track of the stage the level introduction script is at. basic state machine.
    public int State = 0; //originally 0
    public int TutorialState = 0;

    public GameObject MedianEquation;

    public GameObject Tutorial;
    public GameObject DrillDisplay;
    public Image bg;
    public Text TutorialText;
    GameObject drill; //ingame instantiation of the drill prefab
    GameObject median;

    GameObject equation; //ingame instantiation of the mean equation prefab
    GameObject tut; //ingame instantiation of text tutorial of tools
    GameObject temp; //gets the entire object of cube
    BoxCollider currentCollider; //gets the specific box collider from a cube
    GameObject player; //grabby guy

    SpriteRenderer sr;

    void Start()
    {
        bg.enabled = false;
        //TutorialText = Tutorial.GetComponent<Text>();
        Tutorial.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        Tutorial.GetComponent<Canvas>().planeDistance = 1.5f;


        player = GameObject.Find("GrabbyGuy");

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
            if (currentCollider.bounds.Contains(player.transform.position))
                bg.enabled = false;
            temp.SetActive(true);
        }
        else if (State == 2 && OVRInput.GetDown(OVRInput.Button.One))
        {
            bg.enabled = true;
            TutorialText.text = "This is the MEDIAN lesson\n" +
                    "Your goal is to do a time study to determine the central time\n" + "it takes a drill to be assembled\n\n" +
                    "You will be able to proceed in the introduction by\n" + "following the blue glowing areas on the ground\n" +
                    "\nPress A to continue";
            State++;
        }
        else if (State == 3 && OVRInput.GetDown(OVRInput.Button.One))
        {
            TutorialText.text = "The tools available to you are a calculator, a notebook, a stopwatch, and a graph.\n" +
                    "These tools are available at the table, which now has a blue glow in front of it.\n\n" +
                    "When you think you have an answer, submit it to the board behind the table.\n" +
                    "Before beginning, please take a moment to review the description of median." +
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

            MedianDemo();
        }
        else if (State == 5 && OVRInput.GetDown(OVRInput.Button.One))
        {
            Tutorial.gameObject.SetActive(true);
            sr.enabled = false;
            TutorialText.text = "Now you can begin recording data.\n" +
                "Walk over to the blue glow next to the conveyor belt\n and press A to begin producing drills";
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

    void MedianDemo()
    {
        if (equation == null)
        {
            equation = Instantiate(MedianEquation); //instantiates the mean equation demo
            
            sr = GameObject.Find("MedianEQ").GetComponent<SpriteRenderer>();
            sr.enabled = true;
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
