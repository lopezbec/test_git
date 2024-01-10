using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchTeleportButton : MonoBehaviour
{
    public GameObject WatchTool;
    public GameObject Player;
    private Vector3 offset = new Vector3(0.5f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Other)
    {
        WatchTool.transform.position = Player.transform.position + offset;
    }
}
