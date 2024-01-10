using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
     //   if (move) {
     //       door.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
     //       print("move occured");
     //   }
    }

    private void OnTriggerEnter(Collider other)
    {
        //add if statement to clarify this is only for the targeter
      //  move = true;
        print("collision occurred");
    }
}
