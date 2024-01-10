using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscreteCounter : MonoBehaviour
{
    public GameObject graph;
    public GameObject histogram;

    public int pingedVal;
    public List<float> sampleVals = new List<float>(); //samples taken and put into list, each num is put then into the graph, historgram, and board. these are discrete points (should be int?)
    public List<GameObject> buttons = new List<GameObject>(); //gameobject buttons correspond to values
    public List<bool> boolList = new List<bool>(); //coincides with the buttons list, used to set activated buttons and nonactivated ones 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PingButton(int i) //called from int button press. 
    {
        //set all bools to false
        for(int j = 0; j < buttons.Count; j++)
        {
            boolList[j] = false;
            buttons[j].GetComponent<Image>().color = new Color(0, 0, 0);
        }
        //set bool[i] to true
        boolList[i] = true;
        pingedVal = i; 
        buttons[i].GetComponent<Image>().color = new Color(255, 0, 0);
    }

    public void SetActivatedButton() //set which button is currently selected NOT CURRENTLY BEING USED
    {
        for (int j = 0; j < buttons.Count; j++)
        {
            if(boolList[j] != true) //if false,then not active
            {
                buttons[j].GetComponent<Image>().color = new Color(0, 0, 0);
            }
            else //otherwise, set new color and keep it until new item is selected
            {
                
                print(pingedVal);
                buttons[j].GetComponent<Image>().color = new Color(255, 0, 0);
            }
        }
        
    }

    //get input val is called from next Batch set press
    public void getInputVal()
    {
        sampleVals.Add(pingedVal);
        sendToGraph();
        sendToHist();

        //edit which button is being highlighted
        
    }

    public void goToLastInput()
    {
        //sampleTimes[sampleTimes.Count - 1]
    }

    public void sendToGraph() //send sampletimes to graph and add it as a sample
    {
        print("amt of samples is " + sampleVals.Count);
        for (int i = 0; i < sampleVals.Count; i++)
        {
            print(i);
            print("sample: " + sampleVals[i]);
            //graph.GetComponent<GraphManager>().AddSample(sampleVals[i]);
            graph.SendMessage("Addwatch", sampleVals[i]);
        }
    }

    public void sendToHist() //send the sampletimes to the histogram data_points list
    {
        print("histogram should get info");
        histogram.GetComponent<Histogram_Graphing>().ClearTest(); //clear previous datapoints
        histogram.GetComponent<Histogram_Graphing>().data_Points = sampleVals; //send new data over
        histogram.GetComponent<Histogram_Graphing>().startHistogram(1); //create the histogram based on new data -> 1 means discrete

    }
}
