using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartIncoming : MonoBehaviour {

    public GameObject Robot; //robot associated with this field of part detection
    public GameObject Claw; //claw associated with the robot above
    public int defectCount;  //count of all defects that pass through trigger
    public bool defectReady = false; // check if defect is already outside of trigger, ready to be grabbed
    public bool stopConveyer = false; //connected to robot GRAB script
    //variables for light object
    public GameObject errorLight; //red light to glow whenever a defect is stuck on conveyer belt
    public int defectTimer; //amount of time defect is stuck on belt
    public Material redLight;
    public Material offLight; 

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        EndErrorLight();
    }
    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Part" && Robot.GetComponent<Animator>().GetBool("Ready"))//ignore parts passing through this detection field if the robot is currently holding something
        { //if a good part is detected, trigger the "place" animation script to run in the animator controller on the robot
            Robot.GetComponent<Animator>().SetBool("Place", true);
            Robot.GetComponent<Animator>().SetBool("Ready", false);
        }
        if(other.gameObject.tag == "Defect")
        {
            defectCount++;
            Invoke("StartErrorLight", defectTimer);
        }
        if (other.gameObject.tag == "Defect" && Robot.GetComponent<Animator>().GetBool("Ready"))//ignore parts passing through this detection field if the robot is currently holding something
        {//if a bad part is detected, trigger the "discard" animation clip to run in the animator controller on the robot
            //defectCount--;
            Robot.GetComponent<Animator>().SetBool("Discard", true);
            Robot.GetComponent<Animator>().SetBool("Ready", false);
        }
        

        
    }
    
    private void FixedUpdate()
    {
        
        if (Robot.GetComponent<Animator>().GetBool("Ready") && defectCount != 0)
        {
            //defectCount--;
            Robot.GetComponent<Animator>().SetBool("Discard", true);
            Robot.GetComponent<Animator>().SetBool("Ready", false);
        }
        /*
        if (!Robot.GetComponent<Animator>().GetBool("Ready"))
        {

        }

        if (!Claw.GetComponent<Grab>().Primed && defectCount != 0 && !defectReady)
        {
            stopConveyer = true;
        }
        else
        {
            stopConveyer = false;
        }
        */



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Defect" && Robot.GetComponent<Animator>().GetBool("Ready"))
        {
            Robot.GetComponent<Animator>().SetBool("Discard", true);
            Robot.GetComponent<Animator>().SetBool("Ready", false);
        }
        if (other.gameObject.tag == "Defect")
        {
            stopConveyer = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Defect")
        {
            defectCount--;
            CancelInvoke(); //cancel invoking method for error light
        }

        if (defectCount == 0)
        {
            stopConveyer = false;
            EndErrorLight(); //end error light if invoked
        }    
    }
    
    private void ResumeConveyer()
    {
        stopConveyer = false;
        
    }

    private void StartErrorLight()
    {
        errorLight.GetComponent<Renderer>().material = redLight;
        errorLight.GetComponent<Light>().enabled = true;
    }

    private void EndErrorLight()
    {
        errorLight.GetComponent<Renderer>().material = offLight;
        errorLight.GetComponent<Light>().enabled = false;
    }
    
}
