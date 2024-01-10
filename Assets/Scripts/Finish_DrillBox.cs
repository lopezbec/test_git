using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_DrillBox : MonoBehaviour
{
    public int count;//how many finished drills in box
    public GameObject closedBox;//to change open box to a closed one
    public GameObject openBox;//original open box
    public List<GameObject> drills = new List<GameObject>();//list of all drills inside box, to be destroyed once full and closed


    public GameObject worker; //worker that picks up box

    // Start is called before the first frame update
    void Start()
    {
        worker = GameObject.Find("FinishedBoxWorker");
        openBox.SetActive(true);
        closedBox.SetActive(false);
        //worker.gameObject.GetComponent<FinishedBoxWorker>().FinishedBox = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCount()
    {
        return count;
    }

    public void CloseBox()
    {
        openBox.SetActive(false);
        RemoveDrills();
        closedBox.SetActive(true);

        //call worker to take to pallet
        
        //worker.gameObject.GetComponent<FinishedBoxWorker>().setBoxReady(this.gameObject);
    }

    public void AddDrills(GameObject drill)
    {
        count++;
        drills.Add(drill);
    }

    private void RemoveDrills()
    {
        for(int i = 0; i < drills.Count; i++)
        {
            Destroy(drills[i]);
        }
    }
}
