using UnityEngine;

public class Grab : MonoBehaviour {

    public bool Primed = false; //Whether or not the claw is actively trying to grab something
    public bool holding = false; //whether or not the claw is already holding something
  

    public GameObject part; //keeps track of part the claw is holding

    //When an object enters the floating capsule collider in the middle of the claw
    void OnTriggerEnter(Collider other)
    {
     
        //checks to make sure the object is a valid part to pick up (i.e. not the player running on the conveyor belt)
        //Random value between 0.0 and 1.0 is chosen, only has a 5% chance of missing bad part
        if ((Primed == true && (other.tag == "Part" || other.tag == "Defect")) && Random.value <= 0.95f) //Primed is set by the animation clip for grabbing objects is playing
        {
            part = other.gameObject; //keeps track of the part that touched the claw collider

            //claw is no longer primed to pick up an object, as it is now holding one
            Primed = false; 
            holding = true;
        }
    }


    //This only comes into play when the claw is actively holding something
    void Update() {
        if (holding == true) 
        {
            //removes gravity and typical physics from the part it is holding 
            part.GetComponent<Rigidbody>().useGravity = false;
            part.GetComponent<Rigidbody>().isKinematic = true;

            //dynamically assigns the position and rotation of the part to the floating position in the claw to simulate grabbing it
            part.transform.position = gameObject.transform.position;
            part.transform.rotation = gameObject.transform.rotation;
        }
        
        
    }


    //animation event calls a function in AnimationManager that sends a message to its associated claw, containing this script, to execute this function 
    public void Prime() {
        Primed = true; //claw is currently animated and "expecting" a part
    }

    //animation even calls a function in AnimationManager that sends a message to its associated claw, containing this script, to execute this function
    public void Drop() {
        if (part == null)
           return;
        part.GetComponent<Rigidbody>().useGravity = true;
        part.GetComponent<Rigidbody>().isKinematic = false;
        holding = false;
        
        //returns physics to part
        part.GetComponent<Rigidbody>().useGravity = true;
        part.GetComponent<Rigidbody>().isKinematic = false;
        part = null;
        
        
    }

 


}
