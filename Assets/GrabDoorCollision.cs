using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDoorCollision : MonoBehaviour
{
    public Animator myDoor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrillHalf"))
        {
            myDoor.Play("GrabDoor", 0, 0.0f);
            Debug.Log("Collision happened!!!");
        }
    }


}
