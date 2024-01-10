 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsContainer : MonoBehaviour
{
    //test comment for lab update
    public int count;
    //public Queue<GameObject> partsQueue = new Queue<GameObject>();
    public List<GameObject> partsList = new List<GameObject>();
    public GameObject childrenHolder;

    public Text canvasText;
    public GameObject otherBin;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count = partsList.Count;
        if (canvasText != null)
        {
            UpdateCanvas();
        }
    }
    public int getCount()
    {
        return partsList.Count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Defect" || other.gameObject.tag == "DrillHalf")
        {

            //partsQueue.Enqueue(other.gameObject);
            if (!partsList.Contains(other.gameObject))
            {
                partsList.Add(other.gameObject);
                
                //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;-------------------------------------------------
                other.gameObject.transform.parent = childrenHolder.gameObject.transform;  //---------------------------------------------------------------------------------
            }


        }




    }

    public GameObject pickPart()
    {

        //GameObject temp = partsQueue.Dequeue();
        GameObject temp = partsList[0];
        partsList.RemoveAt(0);
        //temp.gameObject.transform.SetParent(childrenHolder.gameObject.transform, false);
        //temp.GetComponent<Rigidbody>().isKinematic = true;
        //temp.gameObject.GetComponent<Rigidbody>().useGravity = true;
        temp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        return temp;
    }

    public int getListLength()
    {
        return partsList.Count;
    }


    private void UpdateCanvas()
    {
        int bin1Total = getListLength();
        int bin2Total = otherBin.GetComponent<PartsContainer>().getListLength();
        int bothBinsTotal = bin1Total + bin2Total;
        canvasText.GetComponent<UnityEngine.UI.Text>().text = "Drill Body Defects\nThis Bin: " + bin1Total + "\nOther Bin: " + bin2Total + "\nTotal: " + bothBinsTotal; 
    }

    public void FreezePart()
    {
        print("FreezePart method called");
        foreach(Transform child in childrenHolder.transform)
        {
            child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
        
}