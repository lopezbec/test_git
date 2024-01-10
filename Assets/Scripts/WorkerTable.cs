using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorkerTable : MonoBehaviour
{

    public Animation anim;

    public GameObject pickUpArea; //this is where the drill components are located for worker to pick up
    public GameObject workArea; //this is where the parts are right in front of the worker
    public GameObject putDownArea;//this is where the workers completed task drill parts are placed
    public Queue<GameObject> drillQueue = new Queue<GameObject>();//this is a queue of drill body parts, which will dequeue two to the drillParts array
    //public int debugCount;
    public GameObject[] drillParts; //drill parts that will be in front of the worker as he does his stuff, taken from queue
    public GameObject[] newPiece; //this is the intermediate builds of the drill to be passed down
                                  //newPiece is an array because it then can be sent nicely with already made scripts, and also in case we want multiple items sent
    public GameObject[] drill; //the newPiece is instantiated inside of this drill
    public GameObject designatedBox; //the designated box that the workers grab items out of, will diminish in 
                                     //amount of items in box after each drill
    public GameObject worker1Bin; //bin that comes from conveyer belt that worker1 pulls drill body parts out of
    public float workerSpeed;// speed of worker
    public bool arePartsReady; //bool to check if all parts are in pickUpArea
    public GameObject prevWorker; // call function in this script for diff workers. Tranfer which drill parts they are under control
    public GameObject nextWorker; // allows simple part hand offs

    //for last table worker (tableworker4)
    public GameObject closedBoxPrefab; //prefab instantiated for finished/closedbox
    public GameObject closedBox;//box used for transport of finished drills
    public int count;//count of finished drills

    //colliders for workers to carry items in their hands
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject itemFromBox;//item that comes out of box and is stored in their right hand until deleted

    public Text canvasText; //canvas for part information
    public int totalDrillsComplete; //drill count for all completed during simulation, for canvas text
    public int totalBoxesComplete; //boxes closed and sent for shipment total for simulation


    public int drillCount = 12; //used to determine when box is full, and should be transported for tableworker 4
    
    public float FinishedBox_X = 0f;
    public float FinishedBox_Z = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        anim.Play("Idle");

        workerSpeed = 2f;

        //test method - comment out later!!---------
        //if (this.gameObject.name == "TableWorker1"){
        //    testing();
        //}
        
    }
    //used to make first worker constantly stream parts down to others for assembly testing
    //void testing(){
    //    SendToPutDown();
    //    Invoke("testing", 1f);
    //
    //}

    // Update is called once per frame
    void Update()
    {
        /*
         * check to see if worker's drill part box is there
         * check to see if the current drill being put to part is there
         * if both are true, call put together function
         * 
        */
        //debugCount = drillQueue.Count;


        if(drillQueue.Count > 0 && drillParts[0] == null)//if queue has items, and array is empty, fill array 
        {
            
            //Invoke("DequeueParts", randomTime);
            DequeueParts();
        }

        if(drillParts[0] != null && itemFromBox != null)//if drill parts arnt empty, and item from box isnt empty, then hold the parts, because he will be making the drill
        {
            for (int i = 0; i < drillParts.Length; i++)
            {
                drillParts[i].transform.position = leftHand.transform.position;
                drillParts[i].transform.rotation = leftHand.transform.rotation;
            }
            itemFromBox.transform.position = rightHand.transform.position;
            itemFromBox.transform.rotation = rightHand.transform.rotation;
        }

        if (designatedBox != null && arePartsReady) // if there is a box, and parts are ready, then put pieces together
        {
            PutTogether();
        }
        else
        {
            if((!arePartsReady) && (drillParts[0] == null))
            {
                anim.Play("Idle");
            }
        }
        

        if(this.gameObject.name == "TableWorker4")//if last worker at the table
        {
            if (closedBox == null)
            {
                closedBox = Instantiate(closedBoxPrefab);
                //closedBox.transform.position = putDownArea.transform.position;
                FinishedBox_X = 0f;
                FinishedBox_Z = 0f;         
                totalBoxesComplete++;
            }


            if (closedBox.GetComponent<Finish_DrillBox>().GetCount() > drillCount) //and the count within the box meets the requirements to close
            {
                closedBox.GetComponent<Finish_DrillBox>().CloseBox();
                //closedBox = Instantiate(); //make new finish box to replace old one 
                nextWorker.GetComponent<FinishedBoxWorker>().setBoxReady(closedBox);
                closedBox = null;
            }
            
        }

        UpdateCanvasText();
    }

    public void PutTogether()
    {
        //move items from pickup area to work area, play animation, then put items in putdown area
        //use for method to call each drill part item in a row
        anim.Play("building");
        //anim.Blend("building");
        
        //print("put together");
        itemFromBox = designatedBox.GetComponent<BoxItems>().TakeItem();


        float randomTime = Random.Range(1, 3); //random time range that the workers will be using for difference placements, until implemented level system
        Invoke("SendToPutDown", randomTime);

        //Invoke("SendToPutDown", workerSpeed); // time for part to be built  using workerSpeed variable when implemented

        
        //Destroy(itemFromBox);
        //itemFromBox = null;

        arePartsReady = false;
        
    }

    public void DequeueParts()//dequeue parts from initial queue and put them in array that will be called in functions
    {
        //take the two body parts out if your the first worker, otherwise, take only one item, as it is the drill
        if (this.gameObject.name == "TableWorker1")
        {
            drillParts[0] = drillQueue.Dequeue();
            drillParts[1] = drillQueue.Dequeue();
            if (drillQueue.Count == 0 || drillQueue.Count == 1) //this is done in case an error arrises and the box has only one item left inside, otherwise it will bug
            {
                RemoveBin();
            }
            //RefillWorker1();
            //drillParts[0] = (worker1Bin.GetComponent<PartsContainer>().pickPart());
            //drillParts[1] = (worker1Bin.GetComponent<PartsContainer>().pickPart());
        }
        else
        {
            drillParts[0] = drillQueue.Dequeue();
        }
        arePartsReady = true;
    }

    public void GiveParts(GameObject[] parts)//put parts into the queue
    {
        for (int i = 0; i < parts.Length; i++)
        {
            
            parts[i].transform.position = pickUpArea.transform.position;
            parts[i].GetComponent<Rigidbody>().Sleep();
            drillQueue.Enqueue(parts[i]);
        }

        
    }
 
    public void GiveBin(GameObject bin) //bin for first worker to pull drill body parts out of and store in queue
    {
        worker1Bin = bin;
        worker1Bin.transform.position = pickUpArea.transform.position;
        worker1Bin.transform.rotation = pickUpArea.transform.rotation;
        print("list length before loop" + worker1Bin.GetComponent<PartsContainer>().getListLength());
        int count = worker1Bin.GetComponent<PartsContainer>().getListLength();
        for (int i = 0; i < count; i++)
        {
            print("put in queue. i = " + i);
            drillQueue.Enqueue(worker1Bin.GetComponent<PartsContainer>().pickPart());
            //drillQueue.Enqueue(worker1Bin.GetComponent<PartsContainer>().pickPart());
        }
        //RefillWorker1();
        

    }
    
    public void RemoveBin()
    {
        GameObject temp = worker1Bin;
        worker1Bin = null;
        Destroy(temp);
    }

    public void GiveBox(GameObject box)//box for specific items for each worker (chuck, battery, switch, )
    {
        designatedBox = box;
    }

    public void SendToPutDown() //send box to next worker, and assign objects to following worker
    {
        //print("Send to putting down area");
        //remove the old components, and replace with only the important parts
        
        drill[0] = Instantiate(newPiece[0]);

        //drill[0].transform.parent = putDownArea.transform;


        //drill[0].transform.position = putDownArea.transform.position;

        RemoveOldParts();

        if (this.gameObject.name == "TableWorker4")//if last worker at the table
        {
            

            //hard coded due to difficulty getting it to work otherwise
            //this is to make the drills assemble in an array to put the finished product away nicely in the final box
            if(FinishedBox_Z >= 0.09f*6){
                FinishedBox_X += 0.6f;  //change this and test?
                FinishedBox_Z = 0.09f;
            }
            else{
                FinishedBox_Z += 0.09f;
            }
            
            drill[0].transform.position = putDownArea.transform.position + new Vector3(FinishedBox_X ,0f ,FinishedBox_Z - 0.36f);
            drill[0].transform.Rotate(0, 90, 0);
            //putDownArea.transform.position += new Vector3(0f,0f,0.05f);
            closedBox.GetComponent<Finish_DrillBox>().AddDrills(drill[0]);
            totalDrillsComplete++;
            
        }
        else
        {

            drill[0].transform.position = putDownArea.transform.position;

        }


        //ADD BACK IN
        if(nextWorker != null)
        {
            if(drill[0] != null)
            {
                
                nextWorker.GetComponent<WorkerTable>().GiveParts(drill);
                drill[0] = null;
                anim.Blend("Idle", 0.001f, 0.1f);
            }
            
            //anim.Play("Idle");

        }
        else
        {
            anim.Blend("Idle",0.99f,0.1f);
            //anim.Play("Idle");
            //FinishPacking();
        }
    }

    public void RemoveOldParts()
    {
        for (int i = 0; i < drillParts.Length; i++)
        {
            Destroy(drillParts[i]);
        }
        GameObject temp = itemFromBox;
        itemFromBox = null;
        Destroy(temp);
    }

    public void FinishPacking()
    {
        closedBox.SetActive(true); //set box to closed
        FinishedBox_X = 0f;
        FinishedBox_Z = 0f;
        totalBoxesComplete++;
    }

    //method for canvas updates
    public void UpdateCanvasText()
    {

        //retrieve box total for each specific worker
        int boxTotalText = designatedBox.GetComponent<BoxItems>().returnItemsRemaining();
        //retrieve total Drills done above with totalDrillsComplete variable
        //retrive totalBoxes complete done above in finishPacking() function with toalboxescomplete
        if(this.gameObject.name == "TableWorker4")
        {
            //retrieve Finished Drills
            int finishedInBoxText = closedBox.GetComponent<Finish_DrillBox>().GetCount();
            canvasText.GetComponent<UnityEngine.UI.Text>().text = "Current In Open Box: " + boxTotalText + "\nFinished Drills: " + finishedInBoxText + "\nTotal Finished Drills: " + totalDrillsComplete + "\nTotal Exported Boxes: " + totalBoxesComplete;
        }
        else{
            canvasText.GetComponent<UnityEngine.UI.Text>().text = "Current In Open Box: " + boxTotalText;
        }


    }


}
