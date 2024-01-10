using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerCarryBox : MonoBehaviour
{
    public GameObject[] table_PlaceBoxSpot; // literal spot on top of table for box to be placed
    public bool[] isTableSpotFull; //checks to see if a box needs to be set on the table
    public bool isActivelyWorking; //checks to see if worker is already setting a box, true means do not check for isTableSpotEmpty
                                    //false means he is ready to place down new box and check if any need placed
    public GameObject[] table_StandSpot; //where worker stands to place box
    public GameObject[] obtainBoxSpot; //where to stand to pick up box from, also holds script to spawn specific box

    public int index; //keeps track which box, tableposition, and location, to place the specific box. 
                      //also important to be used with ontriggerenter functions


    public GameObject heldBoxPosition; //invisible collider to have box held to this position, for holding in hand
    NavMeshAgent navMeshAgent; //gameobject's navmesh agent for ai movement
    public GameObject boxObject; //actual box in hands

    //public Animator anim;//animator to make box carrier just holding box, versus walking with box, or empty handed
    public Animation anim;

    public GameObject designatedWorker; //the table worker that uses this box
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //anim = this.GetComponent<Animator>();
        anim = this.GetComponent<Animation>();
        anim.Play("Idle");
        //SetDestinationPallet();

        //uses index to determine which worker at the table should know that the box is for them
        

    }

    // Update is called once per frame
    void Update()
    {
        if(isActivelyWorking == false)//checks to make sure he can transfer a box, false means he can
        {
            for (int i = 0; i < isTableSpotFull.Length; i++)
            {
                if(isTableSpotFull[i] == false)
                {
                    //print("This table needs a box: Table" + i);
                    //call function to get box
                    index = i;
                    SetDestinationPallet();
                    //set activelyworking to true
                    isActivelyWorking = true;
                    break;
                }
            }
        }



        if(boxObject != null)//is a box in his hand? if so, keep box position and rotation with his hand
        {
            boxObject.transform.position = heldBoxPosition.transform.position;
            boxObject.transform.rotation = heldBoxPosition.transform.rotation;
        }

        if (index == 0)
        {
            designatedWorker = GameObject.Find("TableWorker1");
        }
        else if (index == 1)
        {
            designatedWorker = GameObject.Find("TableWorker2");
        }
        else if (index == 2)
        {
            designatedWorker = GameObject.Find("TableWorker3");
        }
        else if (index == 3)
        {
            designatedWorker = GameObject.Find("TableWorker4");
        }

    }

    private void SetDestinationTable()//GameObject tableSpot)
    {
        Vector3 targetVector = table_StandSpot[index].transform.position;
        //ResetBools();
        //anim.SetBool("isWalking", true);
        anim.Play("BoxWalking");
        navMeshAgent.SetDestination(targetVector);
        
        //workerAnimation.Play(walking.name);

    }

    private void SetDestinationPallet()//GameObject palletSpot)
    {
        Vector3 targetVector = obtainBoxSpot[index].transform.position;
        //ResetBools();
        //anim.SetBool("isWalking", true);
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);

        //workerAnimation.Play(walking.name);

    }

    public void OnTriggerEnter(Collider other)
    {
        //workerAnimation.Stop(walking.name);
        print("Trigger Entered");
        
        if (other.name == "Table1" && index == 0)
        {
            PutDown();
        }
        
        else if (other.name == "Table2" && index == 1)
        {
            PutDown();
        }
        else if (other.name == "Table3" && index == 2)
        {
            PutDown();
        }
        else if (other.name == "Table4" && index == 3)
        {
            PutDown();
        }

        if (other.tag == "Pallet")
        {
            PickUp();
        }
    }

    public void PickUp()//GameObject obtainBox)
    {
        boxObject = obtainBoxSpot[index].GetComponent<PalletBoxHolder>().getBox();
        //boxObject is the object held by worker
        if(boxObject == null) //box empty?
        {
            anim.Play("Idle");
            PickUp();
        }
        else
        {
            SetDestinationTable();
        }
    }

    public void PutDown()//GameObject tableBoxSpot)
    {
        //script for box objects position and rotation, and is now not attached to worker script
        boxObject.transform.position = table_PlaceBoxSpot[index].transform.position;
        boxObject.transform.rotation = table_PlaceBoxSpot[index].transform.rotation;
        
        anim.Play("Idle");
        isActivelyWorking = false;
        isTableSpotFull[index] = true;
        designatedWorker.GetComponent<WorkerTable>().GiveBox(boxObject);
        boxObject = null;
        //configures worker animation
        //ResetBools();
        //anim.SetBool("isIdle", true);
    }


    public void setTableBoolFalse(int temp)
    {
        isTableSpotFull[temp] = false;
    }
}

