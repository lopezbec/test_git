using UnityEngine;

public class ElectricianProductSpawner : MonoBehaviour
{
    System.Random rnd = new System.Random();

    public GameObject Model; //the model or prefab that is to be spawned as the assembled part
    public float Mean = 0f; //the actual theoretical mean value of time taken to assmeble a part
    public float Minimum = 0f; //minimum amount of time to complete a part
    public float SpawnTime; //actual time until next part is completed
    public int LeftHalves, RightHalves = 0; //keeps track of the injected mold halves are available
    public bool Availability = false; //boolean that keeps track of whether all the parts needed to assemble the drill are present
    public float time = 0f; //freerunning timer to keep track of the passage of time

    public GameObject SpawnPoint; //Objects will spawn with this objects transform

    public GameObject left; //placeholders for the two halves that are currently being put together
    public GameObject right;

    void Start() {
        if (Minimum > Mean) //ensures a non-negative spawntime
            Minimum = Mean;
    }

    // Update is called once per frame
    void Update()
    {
        if (Availability){  //only make progress on the next part if all the parts are present
            time += Time.deltaTime;
        }
        else{ //otherwise check again to see if they are available again
            Check();
        }

        if (time > SpawnTime) {//once time passed since beginning has exceeded the spawntime, reset everything and spawn an assembled drill
            Instantiate(Model).transform.position = SpawnPoint.transform.position + new Vector3(0, 0, 1);
            time = 0f;
            Availability = false;
            Destroy(right); //removes the halves from the box to simulate them being taken and used to produce the assembled drill
            Destroy(left);
            
        }
    }

    float ExponentialDistribution() { //generates an exponentially distributed pseudo random decimal value for spawntime
        float random = rnd.Next(1, 10000) / 10000f;
        return ((-1 * (Mean-Minimum) * Mathf.Log(1 - random)) + Minimum);
    }

    void Check() {//call to check for part availibility and begin assembling if everything is present
        if (LeftHalves > 0 && RightHalves > 0) {
            LeftHalves--; 
            RightHalves--;
            Availability = true; //remove the parts from the bin and begin making the next part
            SpawnTime = ExponentialDistribution();

            //grabs two halves and shows them as being used in assembly
            right = GameObject.Find("BodyRight(Clone)");
            left = GameObject.Find("BodyLeft(Clone)");
            right.transform.position = SpawnPoint.transform.position + new Vector3(0.25f,0,0);
            right.transform.rotation = SpawnPoint.transform.rotation;
            left.transform.position = SpawnPoint.transform.position - new Vector3(0.25f, 0, 0);
            left.transform.rotation = SpawnPoint.transform.rotation;
        }
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "BodyRight(Clone)")
            RightHalves++;
        if (other.gameObject.name == "BodyLeft(Clone)")
            LeftHalves++;

    }
}
