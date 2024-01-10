using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportPallet : MonoBehaviour
{
    public int boxCount; //amount of finished drill boxes put into box
    public GameObject forkliftDriver; //driver that will be alerted with crate/pallet is full
    public GameObject boxObject;
    public int boxFullNum = 7; //number at which the box is to be full
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boxObject == null)
        {
            //instantiate a new open box object
        }
    }

    public void RecieveFinishedBox()//this is for the worker to drop a new box into the bigger crate/on the pallet
    {
        boxCount++;
        if(boxCount > boxFullNum)
        {
            print("Crate is full! Get forklift driver");
            AlertForklift();
        }
    }

    public void AlertForklift()
    {
        print("alerting forklift");
        forkliftDriver.GetComponent<ForkliftController>().GetFinishedBox();
    }

    public GameObject GetBox()//getbox is for the forklift to attach the whole crate to the forklift itself
    {
        GameObject temp = boxObject;
        boxObject = null;
        return temp;
    }
}
