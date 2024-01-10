using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate_Tablet_Button : MonoBehaviour
{
    //script is used to update which sample, answer, and distr_type text box should be used depending on which object
    //is currently active for specific sampling page
    public GameObject buttonSample;
    public Text sample;
    public Text answer;
    public Text distrType;
    // Start is called before the first frame update
    void Start()
    {
        buttonSample.SetActive(true);
        buttonSample.GetComponent<Sample>().SampleUpdate(sample, answer, distrType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //inside each page that has these buttons used, have a trigger that will call
    //these with the appropriate information filled out with each one.  Then
    //deactivate after page is changed
    public void SampleButton(Text Sample, Text Answer, Text Distr_Type)
    {
        //activate sampleButton on controller
        //set these game objects to the text ones in sample script
        //now it should work from wherever, and when then use this script 
        //as the booting script.
        //maybe implement this as a script within sample.cs??

    }

    public void HelpButton()
    {

    }

    public void AnswerButton()
    {

    }
}
