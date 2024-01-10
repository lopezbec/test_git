using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public InputAction nextButton;
    private int BoardIndex;
    public GameObject[] Boards;
    public GameObject Camera;
    private Vector3 Offset;
    public GameObject XROrigin;
    public GameObject Reticle;
    public GameObject Wall1;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.Enable();
        BoardIndex = 0;
        Offset.Set(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= Boards.Length - 1; i++)
        
        {
            if(i == BoardIndex)
            {
                Boards[BoardIndex].SetActive(true);
   
                Debug.Log("Board Index = " + BoardIndex + "       I == BI");

            }
            else
            {
                Boards[i].SetActive(false);
                Debug.Log("Board Index = " + BoardIndex + "       I != BI");
            }
        }
        if(nextButton.triggered)
        {
            BoardIndex++;
       

        }
    }
}
