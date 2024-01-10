using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinRegenerator : MonoBehaviour
{
    public GameObject binSpawn; // gameobject that instantiates bins for array. used in ReplaceMiddle() method
    public GameObject[] binsLocation; //gameobject empties that store where the real gameobjects should be placed in the scene
    public GameObject[] bins; //collection of the bin objects on table.  0,1 are the bins that catch parts, 2 is the middle bin that shifts to refill taken bins
    public GameObject Worker; //give worker the needed information for updated bin

    public GameObject canvasText; // canvas with tally of drill housings/parts
    public int totalDrillParts; //total number of drill parts from the start of the current simulation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < bins.Length; i++)
        {
            //go thorugh and see if bin needs replaced
            if(bins[i] == null && i !=2)
            {
                ReplaceBin(i);
            }

            

        }
        UpdateCanvasText();
        
    }

    public void ReplaceBin(int needsReplaced)
    {
        bins[needsReplaced] = bins[2];
        bins[needsReplaced].transform.position = binsLocation[needsReplaced].transform.position;

        //Check which bin needs replaced for worker, give worker the address for new bin in right array
        if(needsReplaced == 0)
        {
            print("inside needsreplaced 0");
            Worker.GetComponent<WorkerScript>().UpdateBinArray(bins[needsReplaced], 0);
            Worker.GetComponent<WorkerScript>().bins[0] = bins[needsReplaced];
            Worker.GetComponent<WorkerScript>().bins[0].transform.localScale = new Vector3(0.000521760783f, 0.000164227269f, 0.000526931894f);
        }
        else if (needsReplaced == 1)
        {
            print("inside needsreplaced 2");
            Worker.GetComponent<WorkerScript>().UpdateBinArray(bins[needsReplaced], 1);
            Worker.GetComponent<WorkerScript>().bins[1] = bins[needsReplaced];
            Worker.GetComponent<WorkerScript>().bins[1].transform.localScale = new Vector3(0.000521760783f, 0.000164227269f, 0.000526931894f);
        }

        ReplaceMiddle();
    }

    public void ReplaceMiddle()
    {
        bins[2] = Instantiate(binSpawn,this.transform);
        bins[2].transform.position = binsLocation[2].transform.position;
    }

    public GameObject RemoveBin(int i)
    {
        //print("RemoveBin called");
        GameObject temp = bins[i];
        bins[i] = null;
        return temp;
    }

    public void UpdateTotal(GameObject bin) //update specific side total, as well as the simulation total
    {

    }

    public void DestroyTotal(GameObject bin) //restart tally for specific side, does not change simulation total
    {

    }

    public void UpdateCanvasText() //update totals for each part of the canvas
    {
        //retrieve the left drill amount
        int leftBinTotal = bins[0].GetComponent<PartsContainer>().getCount();
        //retrieve the right drill amount
        int rightBinTotal = bins[1].GetComponent<PartsContainer>().getCount();
        //combine for total
        int combinedTotal = leftBinTotal + rightBinTotal;
        //print to text
        canvasText.GetComponent<UnityEngine.UI.Text>().text = "Drill Housings\n# Pieces in Left Box: " + leftBinTotal +"\n# Pieces in Right Box: " + rightBinTotal +"\nTotal: " + combinedTotal;

    }


}
