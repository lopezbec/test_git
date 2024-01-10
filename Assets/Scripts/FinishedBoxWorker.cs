using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinishedBoxWorker : MonoBehaviour
{
    public GameObject FinishedBox; //box is on table, it will be updated with which box is on table for complete drills
    public GameObject heldBox; //move finishedbox to this variable, worker holds this and takes it to crate
    public GameObject emptyCrate; //crate that we walk to and fill up with smaller boxes
    public GameObject emptyCratePoint; //point to walk to for empty crate

    public GameObject tablePoint;// where to stand at table

    public NavMeshAgent navMeshAgent;
    public Animation anim;

    public GameObject handTrigger; //where to position box inside hand 

    public bool workerIsReady = false; //true means he is back at table and can pick up a new box
    public bool boxIsReady = false; //true means worker can pick up new finished box

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        SetDestinationAssemblyTable();
    }

    // Update is called once per frame
    void Update()
    {
        if (heldBox != null)//is a box in his hand? if so, keep box position and rotation with his hand
        {
            heldBox.transform.position = handTrigger.transform.position;
            heldBox.transform.rotation = handTrigger.transform.rotation;
        }

        if(boxIsReady == true && workerIsReady == true)
        {
            boxIsReady = false;
            //workerIsReady = false;
            MoveBox();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.name == "Table5" && !workerIsReady)
        {
            WaitForNew();
        }
        if (other.name == "FinishedPalletPoint") //does this have to include name??
        {
            PutDownBox();

        }
    }

    public void setBoxReady(GameObject finishedBox) //worker4 calls on this to set box as finished
    {
        FinishedBox = finishedBox;
        boxIsReady = true;
    }

    public void MoveBox()
    {
        heldBox = FinishedBox;
        FinishedBox = null;
        setDestinationCrate();
        //workerIsReady = false;
        Invoke("MakeWorkerReady", 1f);
    }

    public void MakeWorkerReady() //this is done to offset trigger detection at the table collider.  Waiting prevents triggers from going off
    {
        workerIsReady = false;
    }

    public void WaitForNew()
    {
        anim.Play("Idle");
        workerIsReady = true;
    }

    public void PutDownBox()
    {
        print("put down box");
        //emptycrate script call and store int value inside!
        GameObject temp = heldBox;
        heldBox = null;
        boxIsReady = false;
        emptyCratePoint.gameObject.GetComponent<ExportPallet>().RecieveFinishedBox();
        Destroy(temp);
        //emptycrate.getcomponent<script>().getBox();
        SetDestinationAssemblyTable();
    }

    public void setDestinationCrate()
    {
        if (emptyCrate != null)
        {
            Vector3 targetVector = emptyCratePoint.transform.position;
            anim.Play("BoxWalking");
            navMeshAgent.SetDestination(targetVector);

        }
    }

    private void SetDestinationAssemblyTable()
    {
        Vector3 targetVector = tablePoint.transform.position;
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);

    }
}
