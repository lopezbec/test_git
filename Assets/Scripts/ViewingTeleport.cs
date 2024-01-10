using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewingTeleport : MonoBehaviour
{
    public GameObject Player;
    public GameObject ViewingRoomSpawnPoint;
    private Vector3 spawnPointVector = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        spawnPointVector = ViewingRoomSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.localPosition = spawnPointVector;
    }
}
