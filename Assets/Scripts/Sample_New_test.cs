using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Accord.Statistics.Distributions.Univariate;
using System.Threading;
using System;

public class Sample_New_test : MonoBehaviour
{
    private string[] productionRatedistrTypesArr = { "Exponential", "Continuous", "Triangular" };
    private string[] defectDistrTypesArr = { "Poisson", "Discrete Uniform", "Binomial" };

    //Variables
    private double productionRateCurrent = 1000;
    private double defectChanceCurrent = 0; //0 for no chance, 1 for 100% chance
    private int paramaterShift = 10;  //for max/min values in uniform
    private double numPartsCurrent = 2;
    public double productionRateGen;
    private double cumulGen;
    private int sampledRate;
    private int defectRateCurrent;
    public double productionTime = 0;
    int defectRate;

    public string typeDistrProductionRateCurrent;
    private string typeDistrDefectCurrent;


    public float time = 0; //time since last spawn

    //public List<float> sampleTimes = new List<float>(); //list of times for measuring
    public List<float> dataPoints = new List<float>(); //list that is on the current board, maxed at 10, and pulls from 
    //public List<double> testTimes = new List<double>(); //test list for accurate graph testing


    public GameObject resetTimesButton;
    public Text textSample;
    public Text textAnswer;
    public Text textDistrType;
    public GameObject spawnerMachine;
    public GameObject graph;
    public GameObject histogram;

    //variance specific table
    public Text varianceTable;
    public Text varianceNText;

    public ExponentialDistribution exp;
    public UniformContinuousDistribution ucd;
    public TriangularDistribution tri;

    // Start is called before the first frame update
    void Start()
    {
        startHistogram(2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startHistogram(int i)
    {
        //testing-------------------------------------------

        if (i == 0)
        {
            //exponential
            var exp = new ExponentialDistribution(8);
            double[] samples = exp.Generate(100);
            for (int j = 0; j < samples.Length; j++)
            {
                dataPoints.Add((float)samples[j]);
            }
        }
        // uniform continuous
        if (i == 1)
        {
            int min = Convert.ToInt32(productionRateCurrent) - paramaterShift;
            int max = Convert.ToInt32(productionRateCurrent) + paramaterShift;
            var uni = new UniformContinuousDistribution(min, max);
            double[] samples = uni.Generate(100);
            for (int j = 0; j < samples.Length; j++)
            {
                dataPoints.Add((float)samples[j]);
                histogram.GetComponent<Histogram_Graphing>().addData((float)samples[j]);
            }
        }
        //triangular distribution
        if (i == 2)
        {
            var tri = new TriangularDistribution(6, 12, 9);
            double[] samples = tri.Generate(100);
            for (int j = 0; j < samples.Length; j++)
            {
                dataPoints.Add((float)samples[j]);
                histogram.GetComponent<Histogram_Graphing>().addData((float)samples[j]);
            }
        }

    }


}
