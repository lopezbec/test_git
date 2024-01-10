using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFlash : MonoBehaviour
{

    public GameObject selectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;

    // Start is called before the first frame update
    void Start()
    {
        selectedObject = this.gameObject; 
        pulse1();
        //pulse2();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pulse1()
    {
        redCol = 117;
        greenCol = 154;
        blueCol = 29;
        int range = selectedObject.GetComponent<Renderer>().materials.Length;

        for (int m = 0; m < range; m++)
        {
            gameObject.GetComponent<Renderer>().materials[m].color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
        //selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)blueCol, (byte)greenCol, 255);

        Invoke("pulse2", 2);

    }

    public void pulse2()
    {
        redCol = 92;
        greenCol =  92;
        blueCol = 92;
        int range = selectedObject.GetComponent<Renderer>().materials.Length;

        for (int m = 0; m < range; m++)
        {
            gameObject.GetComponent<Renderer>().materials[m].color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
        Invoke("pulse1", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
