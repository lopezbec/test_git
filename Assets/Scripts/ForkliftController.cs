using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForkliftController : MonoBehaviour
{
    //positions for forklift to travel
    public GameObject[] palletPoints; //points to stand to place pallet down
    public GameObject finishedPallet; //finished crate of drills
    public GameObject finishedPalletPoint; //area to go to to pick up finishedpallet
    //public GameObject point2;
    public bool[] isPalletThere; //checks to see if pallet needs replaced or not
    public bool isActivelyWorking; //checks if forklift actively getting crate
    public bool exportBoxReady; //true if box is ready to be put into a truck for export. called on by exportPallet.cs
    public int index; //keeps track of which number crate is need, helps with location also

    public GameObject truck1; //for unloading
    public GameObject truck2; //for loading finished drill crates
    public GameObject finalDestination;
    public GameObject waitingPosition;//for when worker has nothing to do

    NavMeshAgent navMeshAgent;

    public GameObject forks;//forks on forklift to have box over
    public GameObject forkliftBox;//prefab reference for crate
    private GameObject crate; //instance of forkliftbox that is passed around
    // Start is called before the first frame update
    private bool crateOnFork; //test variable. im having issues with the crate currently
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (crate != null && crateOnFork == true)
        {
            crate.transform.position = forks.transform.position;
        }

        if (isActivelyWorking == false)//checks to make sure he can transfer a crate, false means he can
        {
            for (int i = 0; i < isPalletThere.Length; i++)
            {
                if (palletPoints[i].GetComponent<PalletBoxHolder>().palletBoxes == null)
                {
                    print("This area needs a crate: crate" + i);
                    //call function to get box
                    index = i;
                    SetDestinationTruck();
                    //set activelyworking to true
                    isActivelyWorking = true;
                    break;
                }
            }

            //this is for the exporting boxes
            if(isActivelyWorking == false && exportBoxReady == true)
            {
                isActivelyWorking = true;
                SetDestinationExportPallet();
            }

            
        }
    }

    private void SetDestinationExportPallet()
    {
        Vector3 targetVector = finishedPalletPoint.transform.position;

        navMeshAgent.SetDestination(targetVector);

    }


    private void SetDestinationTruck()
    {
        Vector3 targetVector = truck1.transform.position;
        
        navMeshAgent.SetDestination(targetVector);

    }

    private void SetDestinationWait()
    {
        Vector3 targetVector = waitingPosition.transform.position;

        navMeshAgent.SetDestination(targetVector);
    }

    private void SetDestinationPalletPoint()
    {
        Vector3 targetVector = palletPoints[index].transform.position;

        navMeshAgent.SetDestination(targetVector);
    }

    private void SetDestinationFinishedPalletPoint() //for finished crate
    {
        Vector3 targetVector = finishedPallet.transform.position;

        navMeshAgent.SetDestination(targetVector);
    }

    private void SetDestinationTruck2() //for exporting
    {
        Vector3 targetVector = truck2.transform.position;

        navMeshAgent.SetDestination(targetVector);
    }

    private void SetDestinationFinishedPallet() //for exporting pallet
    {
        Vector3 targetVector = finishedPalletPoint.transform.position;

        navMeshAgent.SetDestination(targetVector);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Truck1" && crateOnFork != true)
        {
            crate = Instantiate(forkliftBox);
            crateOnFork = true;
            SetDestinationPalletPoint();
        }

        if (other.name == "Truck2" && crateOnFork == true)
        {
            Destroy(crate); //we may want to keep track on crates and stuff at some point, so this would be a good spot to edit in the future
            crateOnFork = false;
            isActivelyWorking = false;

            SetDestinationWait();
        }

        if(other.tag == "Pallet")
        {

            palletPoints[index].GetComponent<PalletBoxHolder>().ResetPalletBoxes(crate);
            crate.transform.position = palletPoints[index].transform.position + new Vector3(0,0,1.5f);

            crateOnFork = false;
            isActivelyWorking = false;
            SetDestinationWait();
        }

        if(other.name == "FinishedPalletPoint")
        {
            //connect crate to fork
            //setdestinationtruck2
            crate = Instantiate(forkliftBox);
            exportBoxReady = false;
            crateOnFork = true;
            SetDestinationTruck2();
        }
    }

    public void GetFinishedBox()
    {
        exportBoxReady = true;
        print("export set to true on forklift");
    }




    public void GetNewCrate(GameObject area)
    {
        //finaldestination = area.transform.position
        //setdestination to area
        //when trigger is reached to final destination, place crate in position behind the area, as to not be on top of the collider
    }

    public void LoadCrate()
    {
        //wait for activelyworking to be set off, and then have a variable switch over so it knows to load finished crate. have activelyworking on during this
        //set destination to crate, then afterwards, set destination to truck2
    }
}
