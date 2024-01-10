using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorControl : MonoBehaviour
{
     public Animator myDoor;
     private bool openTrigger = false;
    public GameObject Trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myDoor.Play("DoorSlideDown", 0, 0.0f);
            Debug.Log("Collision happened!!!");
        }
    }


}
