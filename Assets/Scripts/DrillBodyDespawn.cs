using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillBodyDespawn : MonoBehaviour
{
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject;
        Invoke("Despawn", 75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Despawn()
    {
        //Destroy(body);
    }
}
