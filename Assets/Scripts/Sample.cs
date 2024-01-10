#define Graph_And_Chart_PRO
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Accord.Statistics.Distributions.Univariate;
using System.Threading;
using System.Collections;
using ChartAndGraph;
using System.Linq;


public class Sample : MonoBehaviour
{
    private string[] distrubtionType = { "Exponential", "Continuous", "Triangular"};
    private string[] distrubtionDiscreteType = { "Poisson", "Discrete Uniform", "Binomial" };


    //Variables
    private double productionRateCurrent = 750;
    private double defectChanceCurrent = 0.05; //0 for no chance, 1 for 100% chance
    private int paramaterShift = 50;  //for max/min values in uniform
    private double numPartsCurrent = 2;
    public double productionRateGen;
    private double cumulGen;
    private int sampledRate;
    private int defectRateCurrent;
    public double productionTime = 0;
    int defectRate;

    public string typeDistrProductionRateCurrent;
    public string typeDistrDefectCurrent;

    public float time = 0; //time since last spawn
    public int[] defect;
    //code specific for sample
    public List<float> sampleTimes = new List<float>(); //list of times for measuring
    public List<float> graphedTimes = new List<float>(); //list that is on the current board, maxed at 10, and pulls from 

    //stopwatch and sampleTimes
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


    //histogram
    //for testing in inspector
    public bool pressButtonC = false;
    public bool pressButtonD = false;
    //for pressing buttons on tablet
    public bool ButtonC;
    public bool ButtonD;

    //public Text test;
    void Start()
    {
        typeDistrProductionRateCurrent = distrubtionType[0];
        //typeDistrProductionRateCurrent = productionRatedistrTypesArr[1];
        //typeDistrProductionRateCurrent = productionRatedistrTypesArr[2];
        //typeDistrDefectCurrent = defectDistrTypesArr[0];

        //testing
        //ExponentialDistribution ed = new ExponentialDistribution(rate: productionRateCurrent);
        double MinValue = productionRateCurrent - paramaterShift; //production rate - num
        double MaxValue = productionRateCurrent + paramaterShift; //production rate + num
        
    }

    // Update is called once per frame
    void Update()
    {
        defectChanceCurrent = spawnerMachine.GetComponent<BasicSpawner>().defectChanceCurrent;

        productionRateCurrent = spawnerMachine.GetComponent<BasicSpawner>().productionRateCurrent;
        defectChanceCurrent = spawnerMachine.GetComponent<BasicSpawner>().defectChanceCurrent;
        ListUpdate();
        typeDistrProductionRateCurrent = spawnerMachine.GetComponent<BasicSpawner>().getDistTypeC();
        typeDistrDefectCurrent = spawnerMachine.GetComponent<BasicSpawner>().getDistTypeD();
        //testing-----
        
        if(pressButtonC == true)
        {
            pressButtonC = false;
            sampleTimes.Clear();
            graphedTimes.Clear();
            //createData(0, 1000); //cretes sample times (continuous (0) or discrete (1), followed by # of data values)
            sendInformation(0);
        }
        if (pressButtonD == true)
        {
            pressButtonD = false;
            sampleTimes.Clear();
            graphedTimes.Clear();
            //createData(1, 1000);
            sendInformation(1);
        }
        
    }

    public void sendInformation(int i)
    {
        createData(i, 1000);
        //test to create histogram images for instructions

        //for (int j = 0; j < 100; j++)
        //{
        //    test.text += "\n" + Math.Round(sampleTimes[j], 2).ToString();
        //}
        //test.text = "hello";
        sendToHist(i);
        sampleTimes.Clear();
        
        createData(i, 10);
        graph.GetComponent<GraphManager>().clearPoints(); //clear all previous plotting data
        graph.GetComponent<GraphManager>().Clear();
        //sendToBoard();
        sendToGraph();
        //sampleTimes.Clear();

    }

    public void sendToBoard()
    {
        //we want 10 to go to the board
        

    }

    public void sendToGraph()
    {
        print("amt is " + sampleTimes.Count);
        for(int i = 0; i < sampleTimes.Count; i++)
        {
            print(i);
            print("sample: " + sampleTimes[i]);
            graph.GetComponent<GraphManager>().AddSample(sampleTimes[i]);
        }
    }

    public void sendToHist(int i)
    {
        print("histogram should get info");
        histogram.GetComponent<Histogram_Graphing>().ClearTest();
        histogram.GetComponent<Histogram_Graphing>().data_Points = sampleTimes;
        histogram.GetComponent<Histogram_Graphing>().startHistogram(i);

    }

    public void ListUpdate()
    {
        //Updates the text regularly for all components






        if (varianceTable.IsActive())
        {

            varianceNText.text = "N = " + graphedTimes.Count + "\nMean = " + graph.GetComponent<GraphManager>().Mean();
            //varianceTable.text = "Summation Test";
            string varianceTemp = "\n";
            for (int i = 0; i < graphedTimes.Count; i++)
            {
                float step1 = graphedTimes[i] - graph.GetComponent<GraphManager>().Mean();
                float step2 = step1 * step1;
                //varianceTable.text += "\nx" + i + " = " + step1 + "^2 = " + step2;
                varianceTemp += "x" + (i + 1) + " = " + step2.ToString("F2") + "\n";
            }
            varianceTable.text = varianceTemp;

            graphedTimes = graph.GetComponent<GraphManager>().values;
            string result = "Production Time";
            //int tempIndex = 0;
            foreach (var listMember in graphedTimes)
            {

                float temp = listMember;
                result += "\n" + temp.ToString();
                print(temp.ToString("F2"));

                //print("Above should be string");
            }

            textSample.text = result;

            //get average of production time


        }
        else
        {
            //pull from graph list, as well as add to it?
            graphedTimes = graph.GetComponent<GraphManager>().values;
            string result = "Production Time";
            //int tempIndex = 0;
            foreach (var listMember in graphedTimes)
            {

                float temp = listMember;
                result += "\n" + temp.ToString("0.00");
                print(temp.ToString("F2"));

                //print("Above should be string");
            }
            if (textSample != null)
            {
                textSample.text = result;

            }
            //getMean();
            //number added = 10 - length of watch list
            //if equal to 0, add none
            //add clear all button

            //for variance --------------------- fix up later
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Image>().color = Color.cyan;
        //createData();
        ListUpdate();
        //sampleTimes.Clear();

        //Invoke("MakeAvail", 0.5f);
        if (ButtonC)
        {
            print("made it C");
            sampleTimes.Clear();
            graphedTimes.Clear();
            sendInformation(0);
        }
        if (ButtonD)
        {
            print("made it D");
            sampleTimes.Clear();
            graphedTimes.Clear();
            sendInformation(1);
        }

    }

    public void TriggerButton()
    {
        GetComponent<Image>().color = Color.cyan;
        //createData();
        ListUpdate();
        //sampleTimes.Clear();

        //Invoke("MakeAvail", 0.5f);
        if (ButtonC)
        {
            print("made it C");
            sampleTimes.Clear();
            graphedTimes.Clear();
            sendInformation(0);
        }
        if (ButtonD)
        {
            print("made it D");
            sampleTimes.Clear();
            graphedTimes.Clear();
            sendInformation(1);
        }

    }

    public void createData(int i, int amt)
    {

        
        if(i == 0){ //create continuous data
            print("continuous");

            if (typeDistrProductionRateCurrent == distrubtionType[0])
            {
                print("exp");
                //exponential
                var exp = new ExponentialDistribution(productionRateCurrent);
                double[] samples = exp.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add((float)samples[j] * 3600);
                }
            }
            // uniform continuous

            if (typeDistrProductionRateCurrent == distrubtionType[1])
            {
                var uni = new UniformContinuousDistribution(productionRateCurrent - paramaterShift, productionRateCurrent + paramaterShift);
                double[] samples = uni.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add((1 / (float)samples[j]) * 3600);
                }
            }

            //triangular distribution
            if (typeDistrProductionRateCurrent == distrubtionType[2])
            {
                var tri = new TriangularDistribution(productionRateCurrent - paramaterShift, productionRateCurrent + paramaterShift, productionRateCurrent);
                double[] samples = tri.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add((1 / (float)samples[j]) * 3600);
                }
            }
        }
        if(i == 1) //create discrete data
        {
            print("discrete. cur defect: " + defectChanceCurrent);
            //----------DISCRETE--------------
            if (typeDistrDefectCurrent == distrubtionDiscreteType[0])
            {
                var Poi = new PoissonDistribution(lambda: (defectChanceCurrent * productionRateCurrent));
                int[] samples = Poi.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add(samples[j]);
                }
            }

            if (typeDistrDefectCurrent == distrubtionDiscreteType[1])
            {
                int MinValue = Convert.ToInt32(productionRateCurrent) - paramaterShift;
                int MaxValue = Convert.ToInt32(productionRateCurrent) + paramaterShift;
                var udd = new UniformDiscreteDistribution(Convert.ToInt32(defectChanceCurrent * MinValue), Convert.ToInt32(defectChanceCurrent * MaxValue));
                int[] samples = udd.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add(samples[j]);
                }
            }

            if (typeDistrDefectCurrent == distrubtionDiscreteType[2])
            {
                var bd = new BinomialDistribution(Convert.ToInt32(productionRateCurrent), defectChanceCurrent);

                int[] samples = bd.Generate(amt);
                for (int j = 0; j < samples.Length; j++)
                {
                    sampleTimes.Add(samples[j]);
                }
            }
        }
        

    }

    public void getAnswer()
    {
        //change to float for mean
        /*
        float answer = 0;
        foreach (var listMember in sampleTimes)
        {
            answer += (float)listMember;
        }
        answer = (float)(answer / 10);
        textAnswer.text = "" + answer;
        */
        if (textAnswer.name == "MeanSolution")
        {
            textAnswer.text = graph.GetComponent<GraphManager>().Mean().ToString("0.00");

        }
        else if (textAnswer.name == "MedianSolution")
        {
            textAnswer.text = graph.GetComponent<GraphManager>().Median().ToString("0.00");

        }
        else if (textAnswer.name == "ModeSolution")
        {
            textAnswer.text = graph.GetComponent<GraphManager>().Mode().ToString("0.00");

        }
        else if (textAnswer.name == "VarianceSolution")
        {
            textAnswer.text = "Answer: " + graph.GetComponent<GraphManager>().Variance().ToString("0.00");

            //varianceNText.text = "N = " + graphedTimes.Count;
            //varianceTable.text = "Summation";

            /*
            for (int i = 0; i < graphedTimes.Count; i++)
            {
                float step1 = graphedTimes[i - 1] - graph.GetComponent<GraphManager>().Mean();

                float step2 = step1 * step1;
                varianceTable.text += "\n x" + i + " = " + step1 + "^2 = " + step2;
            }
            */

        }
        else
        {
            textAnswer.text = "Error getting answer";

        }

    }




    public void SampleUpdate(Text Sample, Text Answer, Text Distr_Type) //function called from Activate_Tablet_Button.cs
    {
        textSample = Sample;
        textAnswer = Answer;
        textDistrType = Distr_Type;

    }
}

