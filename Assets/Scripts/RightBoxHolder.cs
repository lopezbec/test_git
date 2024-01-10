using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBoxHolder : MonoBehaviour
{
    public int numBoxes;
    private int refreshNumber;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        numBoxes = 5;
        refreshNumber = numBoxes;
    }
    public GameObject getBox()
    {
        if (numBoxes > 0)
        {
            numBoxes--;
            return Instantiate(box);
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
