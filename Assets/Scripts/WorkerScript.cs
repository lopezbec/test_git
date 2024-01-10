using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerScript : MonoBehaviour
{
    //bin transforms and gameobjects(for partscontainer script)
    public Transform drillBodyBin1;
    
    //below is new drillbody transform for array
    public Transform[] drillBodyBins;

    public GameObject binRegeneratorObject; //used to replace bins after taken by worker

    public GameObject finishedCrate_Position; //cube that is placed in front of the crate
    //public Transform drillBodyBin2;
    //public Transform table_work;
    //public Transform table_box;

    public GameObject[] bins; //both bins are stored here NEW------
    public GameObject heldBin; //bin that is picked up and stored in workers hands, eventually transfered to table workers
    public int binIndex; //used to determine which box to pickup in pickup method
    public int fullNum = 14; //number for when box is ready for pickup


    public GameObject handTrigger;
    public GameObject[] drillbody;
    public GameObject tableTop;
    public GameObject tableSpot;
    public GameObject finishedCrate;
    public GameObject finishedBox; //box that will go to the crate 
    //booleans to determine routine and which steps are allowed
    public bool isWalk;
    public bool isIdle;
    public bool isBuilding;
    public bool isHolding;
    public bool atBin1;
    public bool atBin2;
    public bool atTable;

    NavMeshAgent navMeshAgent;

    //different animationclips for the animation component
    private Animation workerAnimation;
    public AnimationClip walking;
    public AnimationClip idle;
    public AnimationClip pickUpClip;

    public Animation anim;

    public GameObject nextWorker;//use to give first table worker the drill body parts

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();

        navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");
        isIdle = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (isHolding == true)
        {
            /*OLD CODE 
            for (int i = 0; i < drillbody.Length; i++)
            {
                drillbody[i].transform.position = handTrigger.transform.position;
                drillbody[i].transform.rotation = handTrigger.transform.rotation;
            }
            */
            //NEW CODE

            heldBin.transform.position = handTrigger.transform.position;
            heldBin.transform.rotation = handTrigger.transform.rotation;

            SetDestinationTable1();

            //new isholding check update
            //heldBin.transform.position = handTrigger.transform.position;
            //SetDestinationTable1();
        }

        //print("Queue: " + Bin1.GetComponent<PartsContainer>().getQueueLength());

        //CHECK IF BIN1 IS READY FOR PICKUP, GO TO IT, ONCE THERE, PICKUP FUNCTION CALLED
        
        if (atBin1 && bins[0].GetComponent<PartsContainer>().getListLength() >= fullNum)
        {
            pickUp();
        }

        //if ((Bin1.GetComponent<PartsContainer>().getListLength() != 0) && (anim.clip.name == "Idle"))
        //{
        //    SetDestinationBin1();
        //}

        //CHECK IF BIN2 IS READY FOR PICKUP AND SEND TO DESTINATION
        if (atBin2 && bins[1].GetComponent<PartsContainer>().getListLength() >= fullNum)
        {
            pickUp();
        }
        
        

        /*
        if (Bin1.GetComponent<PartsContainer>().count > 0 && isIdle && !isHolding && !atBin1)
        {
            //make all booleans false
            isIdle = false;

            //call method for specific acction
            SetDestinationBin1();//when there is a part, go grab it


        }
        */
        //updated bin if statement for checking both bins
        for (int i = 0; i < bins.Length; i++)
        {
            //print("inside loop");
            //print(i + " bin -> count: " + bins[i].GetComponent<PartsContainer>().count);
            
            if (bins[i] != null && bins[i].GetComponent<PartsContainer>().count >= fullNum && isIdle && !isHolding)
            {
                
                binIndex = i;
                isIdle = false;
                SetDestinationBin();
            }
        }

        if (isHolding)
        {

            atBin1 = false;
            atBin2 = false;

        }

        
        

    }

    public void OnTriggerEnter(Collider other)
    {
        //edit this to work with two bins
        //print("Trigger Entered");
        if (other.name == "BinTrigger")
        {
            //print("found bin name");

            atBin1 = true;

            anim.Play("Idle");


            this.transform.LookAt(bins[0].transform);



        }
        if (other.name == "BinTrigger2")
        {
            //print("found bin name");

            atBin2 = true;

            anim.Play("Idle");


            this.transform.LookAt(bins[1].transform);



        }
        if (other.name == "Table")
        {
            //print("found Table name");


            this.transform.LookAt(tableTop.transform);
            anim.Play("Idle");
            putDown();
            

        }
    }

    public void OnTriggerExit(Collider other)
    {

        //print("Trigger Entered");
        if (other.name == "BinTrigger")
        {

            atBin1 = false;


        }
        if (other.name == "Table")
        {

            atTable = false;

        }
    }
    //old method (still in use)
    private void SetDestinationBin1()
    {
        if (drillBodyBin1 != null)
        {
            Vector3 targetVector = drillBodyBin1.transform.position;
            anim.Play(walking.name);
            navMeshAgent.SetDestination(targetVector);
            


        }
    }
    //new method for bins (incomplete)
    private void SetDestinationBin()
    {
        if (drillBodyBins[binIndex] != null)
        {
            Vector3 targetVector = drillBodyBins[binIndex].transform.position;
            anim.Play(walking.name);
            navMeshAgent.SetDestination(targetVector);



        }
    }

    private void SetDestinationTable1()
    {
        if (tableSpot != null)
        {
            Vector3 targetVector = tableSpot.transform.position;
            navMeshAgent.SetDestination(targetVector);
            //anim.Play(walking.name);
            anim.Play("BoxWalking");


        }
        else
        {
            anim.Play(idle.name);


        }
    }

    private void SetDestinationFinishedCrate()
    {
        if (finishedCrate_Position != null)
        {
            Vector3 targetVector = finishedCrate_Position.transform.position;
            anim.Play(walking.name);
            navMeshAgent.SetDestination(targetVector);

        }
    }

    //IEnumerator Waiter()
    //{
    //    anim.Play(pickUpClip.name);
    //    yield return new WaitForSeconds(5);
    //
    //}

    private void pickUp()
    {
        /*
        drillbody[0] = Bin1.GetComponent<PartsContainer>().pickPart();
        drillbody[1] = Bin1.GetComponent<PartsContainer>().pickPart();
        isHolding = true;
        for (int i = 0; i < drillbody.Length; i++)
        {
            drillbody[i].transform.position = handTrigger.transform.position;
            drillbody[i].transform.rotation = handTrigger.transform.rotation;
        }
        */



        //Below is the updated pickup method
        //pick up entire box of parts
        //walk over to position he normally does
        //place box down on table where single drill body pieces once went (have table worker pull from the queue directly in script for box)

        
        heldBin = bins[binIndex];
        heldBin.transform.position = handTrigger.transform.position;
        heldBin.transform.rotation = handTrigger.transform.rotation;
        isHolding = true;
        anim.Play("BoxIdle");
        heldBin.GetComponent<PartsContainer>().FreezePart();
        bins[binIndex] =binRegeneratorObject.GetComponent<BinRegenerator>().RemoveBin(binIndex);  //must in future fix so 0 is not hardcoded will only remove bin1 not bin2
        //drillBodyBins[binIndex] = bins[binIndex].transform; //^^ i removed zeros and put binidex
        //StartCoroutine(Waiter());
    }

    private void putDown()
    {
        //drillbody.transform.position = tableTop.transform.position;
        //drillbody.GetComponent<Rigidbody>().Sleep();
        /*
        isHolding = false;
        atBin1 = false;
        isIdle = true;
        anim.Play(idle.name);

        nextWorker.GetComponent<WorkerTable>().GiveParts(drillbody);
        //delete from this workers variables
        drillbody[0] = null;
        drillbody[1] = null;

        */
        //new code
        if (isHolding)
        {
            //bins[binIndex] = null;
            isHolding = false;
            atBin1 = false;
            isIdle = true;
            anim.Play(idle.name);
            nextWorker.GetComponent<WorkerTable>().GiveBin(heldBin); //have to change method in other class to accept a gameobject, and then call on dequeue from that gameobject
            anim.Play(idle.name);
            heldBin = null;
        }
        

    }

    public void UpdateBinArray(GameObject bin, int i) //BinRegenerator calls this script, which then allows the worker to receive a bin in index i
    {
        print("updatebinarray called");
        bins[i] = bin;
    }
    
}
