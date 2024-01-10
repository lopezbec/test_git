using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletBoxHolder : MonoBehaviour
{
    public GameObject palletBoxes; //gameobject of boxes and pallet
    public int numBoxes; //number of boxes located inside of this container to be "taken". When zero, gameobject is deleted
    public GameObject box; //individual box returned to worker. Modular, and can have different items in each box
    private int refreshNumber; //used to reinvoke same amount of box numbers when new crate is placed
    // Start is called before the first frame update
    void Start()
    {
        numBoxes = 5;
        refreshNumber = numBoxes;
    }

    // Update is called once per frame
    void Update()
    {
        if (numBoxes < 1)
        {
            //let forklift know that new crate/pallet is needed
            //Destroy(); destroy the crate, needs to be attached at some point
            Destroy(palletBoxes);
            //alert forklift driver that new crate is needed
            //GameObject forkliftWorker = GameObject.Find("ForkliftWorker");
            //forkliftWorker.GetComponent<ForkliftController>()
        }
    }

    public GameObject getBox()
    {
        if(numBoxes > 0)
        {
            numBoxes--;
            return Instantiate(box);
        }
        
        return null;
    }

    public void ResetPalletBoxes(GameObject crate)
    {
        numBoxes = refreshNumber;
        palletBoxes = crate;
        //palletBoxes.transform.position = this.transform.position;// + new Vector3(0,0,3);
    }
}
