using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItems : MonoBehaviour
{
    public int itemsRemaining; //items remaining inside of this box. depends on what kind of box it is, each box has
                               //different amount of items inside
    public GameObject item; //item that assembly workers take out of box to put inside drill
    public GameObject boxWorker; //worker that needs a function call to know that this specific box is empty
    public int index; //index is sent to the boxWorker gameobject, making the boolean false
    // Start is called before the first frame update
    void Start()
    {
        boxWorker = GameObject.Find("BoxWorker"); //name of the worker who brings all the boxes, if name changed, code needs changed also
    }

    // Update is called once per frame
    void Update()
    {
        if (itemsRemaining < 1)
        {
            boxWorker.GetComponent<WorkerCarryBox>().setTableBoolFalse(index);
            Destroy(this.gameObject);
        }
    }

    public GameObject TakeItem()
    {
        if(itemsRemaining > 0)
        {
            itemsRemaining--;
            return Instantiate(item);
        }

        else
        {          
            //have gameobject delete itself? 
            return null;
        }
    }

    public int returnItemsRemaining()
    {
        return itemsRemaining;
    }
}
