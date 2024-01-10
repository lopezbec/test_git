using UnityEngine;

//Script placed on robot asset, general control for animations
public class AnimationManager : MonoBehaviour {



    public GameObject Claw; //Use the Unity editor to click and drag the "ClawCollider" child object to this spot 
    private AudioSource sound; //main audio source component attached in the editor
    private AudioSource audioSource; //secondary audio source component made to play second audio clip during animation 


    public AudioClip Servo; //the audioclip for refined servo movement of the robot
    public AudioClip Motor;//the sound of the electric motor running on the robot


    public void Start() {
        //initializes the secondary audio source component
        //tune these values to improve quality of sound
        GameObject servo = new GameObject("ServoAudio");
        servo.transform.position = transform.position;
        audioSource = servo.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = Servo;
        audioSource.volume = 0.8f;
        audioSource.pitch = 2.0f;
        audioSource.spatialBlend = 1.0f;
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 10.0f;

        sound = gameObject.GetComponent<AudioSource>();
    }


    //function called by animation event, primes the claw so that it knows to grab the next part that comes to it
    public void PrimeClaw() { //called by event in animation clip to prime the claw collider
        Claw.GetComponent<Grab>().Primed = true;
        
    }

    //function called by animation event, triggers the claw to let go of whatever it is holding
    public void Drop() { //called by event in animation clip to drop part from the claw collider
        Claw.SendMessage("Drop");

    }


    //receives an integer from the slider on the terminal, scales the speed of animations base on 3 being the default.
    public void UpdateSpeed(int Speed) { //receives value and updates animation speed based on this value 

        gameObject.GetComponent<Animator>().speed = Speed/2.0f; //whatever your default "normal" speed is on the terminal slider is what you should divide by here

        //gameObject.GetComponent<AudioSource>().pitch = Speed / 2.0f; //updates the speed of the sound as well (alters pitch too)

        /***NOTE***
         * Also make sure to edit the script that came with the conveyor belts 
         * so that their speed also scaled to match the robot, 
         * automatically fixing any timing issues with animation speeds.
         * This can be changed by finding the UpdateSpeed(int Speed) function,
         * located in the script attached to every conveyor belt asset
         */

    }


    /*This function is called by an animation event in various clips involving the robot arm. 
     * It works by setting the ready bit to true, while also resetting any place or discard signals that 
     * may have been passed by parts coming down the line faster than the robot can react to.
     * Without the resetting of these bits, the robot will try to pick up a part once it has already passed it on the belt, 
     * and become out of sync with the parts as they come down the conveyor belt.
    */
    public void Ready() {
        gameObject.GetComponent<Animator>().SetBool("Place", false);
        gameObject.GetComponent<Animator>().SetBool("Discard", false);
        gameObject.GetComponent<Animator>().SetBool("Ready", true);
        
    }

    public void MotorSound(){ //function called by animation event to generate motor sound
        sound.clip = Motor;
        sound.timeSamples = 10000;
        sound.Play();
    }

    public void ServoSound(){ //function called by animation event to generate servo sound
        audioSource.clip = Servo;
        audioSource.timeSamples = 31200; //offsets to the appropriate part of the clip so the sound syncs up nicely
        audioSource.Play();
    }


}
