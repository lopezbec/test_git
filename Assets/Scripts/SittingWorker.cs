using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingWorker : MonoBehaviour
{
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        anim.Play("Driving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
