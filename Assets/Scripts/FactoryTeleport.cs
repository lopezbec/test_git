using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FactoryTeleport : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.localPosition = new Vector3(28.88f, 0.0f, -8.78f);
    }
}
