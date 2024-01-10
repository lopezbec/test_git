using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//using Valve.VR;

public class StopWatchManager : MonoBehaviour
{
    //public SteamVR_Action_Boolean stopwatch = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Stopwatch");
    //public SteamVR_Action_Boolean stopwatchMarkOnGraph = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("StopwatchMarkOnGraph");
    //public  SteamVR_Input_Sources hand;
    bool recording = false;
    bool hasPressedX = false;
    bool hasRecorded = false;
    public bool lockedX = false;
    public bool lockedY = false;
    Canvas canvas;
    Text watchDisplay; //text UI element to show seconds since toggling in real time
    GameObject Graph; //graphing tool gameobject to record laps
    public GameObject histogram;
    float timer = 0f; //total running time of the watch
    float lastLap = 0.0f; //keeps track of the time value when the last time a lap was recorded to calculate the next lap
    public InputAction xButton;
    public InputAction yButton;

    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        watchDisplay = GameObject.Find("WatchTime").GetComponent<Text>();
        Graph = GameObject.Find("Graph");
        xButton.Enable();
        yButton.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
        //continually updates the display for realtime stopwatch functionality
        if (recording){
            timer = timer + Time.deltaTime; //actual running stopwatch timer
            watchDisplay.text = timer.ToString("0.00") + "s";
        }

            //OVRInput.GetDown(OVRInput.Button.Three)
          
            bool stopwatchcontrol = false;
            //stopwatchcontrol = stopwatch.GetStateDown(hand); 
            if(xButton.IsPressed() && !lockedX)
        {
            lockedX = true;
            stopwatchcontrol = !stopwatchcontrol;
            Invoke("unLock", 0.2f);
        }
       

            bool stopwatchMarkOnGraphControl = false;
        if(yButton.IsPressed() && !lockedY)
        {
            lockedY = true;
            stopwatchMarkOnGraphControl = !stopwatchMarkOnGraphControl;
            Invoke("unLock", 0.2f);
        }
            //stopwatchMarkOnGraphControl= stopwatchMarkOnGraph.GetStateDown(hand);
            //Toggle the stopwatch
            if (stopwatchcontrol && canvas.enabled)
            { //space bar toggles if the stopwatch is running
                recording = !recording;
                hasPressedX = false;
                if (hasRecorded == true)
                {
                    hasRecorded = false;
                }
            }

            //trigger a lap for the stopwatch to be recorded 
            if (stopwatchMarkOnGraphControl && canvas.enabled && !hasPressedX && !recording && !hasRecorded)
            {
                
                Graph.SendMessage("Addwatch", timer - lastLap);
                histogram.GetComponent<Histogram_Graphing>().watchTimes.Add(timer - lastLap);        
                lastLap = timer;
                timer = 0.0f;
                lastLap = 0.0f;
                hasRecorded = true;
            }
        
        */

        //TESTING**************************************
        if (recording)
        {
            timer = timer + Time.deltaTime; //actual running stopwatch timer
            watchDisplay.text = timer.ToString("0.00") + "s";
        }

        //OVRInput.GetDown(OVRInput.Button.Three)

        bool stopwatchcontrol = false;
        //stopwatchcontrol = stopwatch.GetStateDown(hand); 
        if ((xButton.IsPressed() || Input.GetKeyDown(KeyCode.X)) && !lockedX)
        {
            lockedX = true;
            stopwatchcontrol = !stopwatchcontrol;
            Invoke("unLock", 0.2f);
        }


        bool stopwatchMarkOnGraphControl = false;
        if ((yButton.IsPressed() || Input.GetKeyDown(KeyCode.Y)) && !lockedY)
        {
            lockedY = true;
            stopwatchMarkOnGraphControl = !stopwatchMarkOnGraphControl;
            Invoke("unLock", 0.2f);
        }
        //stopwatchMarkOnGraphControl= stopwatchMarkOnGraph.GetStateDown(hand);
        //Toggle the stopwatch
        if (stopwatchcontrol && canvas.enabled)
        { //space bar toggles if the stopwatch is running
            recording = !recording;
            hasPressedX = false;
            if (hasRecorded == true)
            {
                hasRecorded = false;
            }
        }

        //trigger a lap for the stopwatch to be recorded 
        if (stopwatchMarkOnGraphControl && canvas.enabled && !hasPressedX && !recording && !hasRecorded)
        {

            Graph.SendMessage("Addwatch", timer - lastLap);
            //histogram.GetComponent<Histogram_Graphing>().watchTimes.Add(timer - lastLap);
            histogram.GetComponent<Histogram_Graphing>().AddStopWatchVal(timer - lastLap);
            lastLap = timer;
            timer = 0.0f;
            lastLap = 0.0f;
            hasRecorded = true;
        }
    }

    public void unLock()
        {
            lockedX = false;
            lockedY = false;
        }

}
