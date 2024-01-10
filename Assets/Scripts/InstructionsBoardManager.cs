using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionsBoardManager : MonoBehaviour
{
    public Text SampleData;
    public Text Solution;
    public Text DistrTypeInstrBoard;
    public GameObject SolutionDisplay;
    public double[] InternalSample;
    public static double[] sample;
    public static List<double> values = new List<double>(); //list of all values from the sampling

    // Start is called before the first frame update
    void Start()
    {
        //SampleData = GetComponent<Text>();
    }

    //Adds together all of the values in the sample
    public double Sum()
    {
        double sum = 0;
        for (int i = 0; i < values.Count; i++)
        { 
            sum += values[i];
        }
        return sum;
    }

    //calculates mean
    public void Mean()
    {
        //solution = Sum() / values.Count;
 
    }


    // Update is called once per frame
    void Update()
    {
        InternalSample = sample;
        //SolutionDisplay.GetComponent<Text>().text = "Sample is" + InternalSample;
        //Sample();
        //SampleData.text = "sample data is " + sample.ToString;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    SampleData.text = "sample data is" + sample;

    //}
}
