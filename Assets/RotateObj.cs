using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
    
{
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     //   yPos = this.transform.rotation.y;
    //    yPos++;
        this.transform.Rotate(0f, 0f, 1f);

    }
    public void rotate()
    {
        this.transform.Rotate(0f, 0f, 1f);
    }
}
