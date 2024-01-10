using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTools : MonoBehaviour
{

    //public GameObject tablet;
    //public GameObject stopWatch;
    public GameObject tool;
    public Vector3 spawnDistance = new Vector3(0, 0, 0); //distance from player to spawn object in front of
    public GameObject player_Tool_Spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerButton()
    {
        tool.transform.position = player_Tool_Spawn.transform.position;
    }
}
