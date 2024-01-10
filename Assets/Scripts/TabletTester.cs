using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabletTester : MonoBehaviour
{

    public Button forwardButton;
    public Button prevButton;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button submitButton; //goes to next batch

    public bool bool0;
    public bool bool1;
    public bool bool2;
    public bool bool3;
    public bool bool4;
    public bool bool5;
    public bool bool6;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bool0)
        {
            forwardButton.onClick.Invoke();
            bool0 = false;
        }
        if (bool1)
        {
            prevButton.onClick.Invoke();
            bool1 = false;
        }
        if (bool2)
        {
            button0.onClick.Invoke();
            bool2 = false;
        }
        if (bool3)
        {
            button1.onClick.Invoke();
            bool3 = false;
        }
        if (bool4)
        {
            button2.onClick.Invoke();
            bool4 = false;
        }
        if (bool5)
        {
            button3.onClick.Invoke();
            bool5 = false;
        }
        if (bool6)
        {
            submitButton.onClick.Invoke();
            bool6 = false;
        }
        
    }




}
