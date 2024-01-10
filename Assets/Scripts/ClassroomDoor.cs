using UnityEngine;

public class ClassroomDoor : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            GameObject.Find("Master").GetComponent<LevelMaster>().State++;
    }


}
