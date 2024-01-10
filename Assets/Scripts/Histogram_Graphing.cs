#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using ChartAndGraph;
using System.Collections.Generic;
using System;
using System.Linq;
using Accord.Statistics.Distributions.Univariate;
using UnityEngine.UI;

public class Histogram_Graphing : MonoBehaviour
{

    //steps in order for functions
    /*
    1) Start
    2) Boolean is pressed and checked in update
    3) startHistogram (int i) i for which distribution
    4) Make_Interval(min, max)
        -Puts interval values (each bin has an interval of values) into array
        -increment up by specific interval
    5) AddBin()
        -loops through bin count to name according to bin_interval values
    6) AddData to histogram (relative or by value)
        -goes through all datapoints and checks where each point should be placed for bins
    Notes:
    -some functions are split for discrete and continuous

    */

    //values for histogram manipulation
    public float max; //max number in data
    public float min; //min number in data
    public double frequencyVal; //value for each frequency to flunctuate through
    public int totalDataPoints; //total number of data points
    public int bin_count; //amount of bins desired for histogram (intervals/buckets/classes)
    public List<double> interval_Array; //array for searching where to put new data points
    public List<float> data_Points; //all the continuous data points put into the histogram from sample.cs script
    public List<float> discrete_data_Points; //all the discrete data points put into the histogram from sample.cs script
    public List<float> watchTimes; //times sent here from stopwatch. controlled separately from generated data points, combined later
    public bool runExp = false; //if true, have histogram run through all its data and create it
    public bool runUni = false; //if true, have histogram run through all its data and create it
    public bool runTri = false; //if true, have histogram run through all its data and create it
    public bool runPoi = false; //if true, run discrete poison information
    public bool runDisUni = false;
    public bool runBin = false;

    public bool isFirst = true;
    public bool runSimulationC = false;
    public bool runSimulationD = false;

    public GameObject title;
    public Text x;
    public Text y;

    class RunChartEntry
    {
        public RunChartEntry(string name, double interval, double[] values)
        {
            Name = name;
            Interval = interval;
            
        }
        public string Name;
        public double Interval; //value appearing on histogram (# of data in range)
        public double[] maxValue; //values stored within this bin/interval
    }

    public float switchTime = 0.1f;
    float switchTimeCounter = 0f;

    List<RunChartEntry> mEntries = new List<RunChartEntry>();
    public Material SourceMaterial;
    // Use this for initialization
    void Start()
    {
        switchTimeCounter = switchTime;

        
        var bar = GetComponent<BarChart>();
        bar.TransitionTimeBetaFeature = switchTime;
        bar.DataSource.ClearCategories();
        bar.DataSource.ClearGroups();
        bar.DataSource.AddGroup("Default");

    }

    public void startHistogram(int i)
    {

        if (isFirst == true)
        {
            isFirst = false;
        }
        else
        {
            //Clear();
        }

        //end testing---------------------------------------

        if (i == 0) // for continuous
        {
            //change x title
            x.text = "Time Between Drill Batches";
            data_Points.Sort();
            //data_Points.RemoveAt(0);
            //data_Points.RemoveAt(data_Points.Count - 1);
            min = data_Points.Min();
            max = data_Points.Max();
            Make_Interval_C(min, max); //use min/max to get range, frequency
                                     //AddBin_C(); //set up bins based on intervals
            AddBin_C();
            //AddData_To_Hist();
            AddData_To_Hist_Relative_C();
        }
        else // for discrete
        {
            //change x title
            x.text = "Number of Defective Drill Batches";
            data_Points.Sort();
            min = data_Points.Min();
            max = data_Points.Max();
            Make_Interval_D((int)min, (int)max);
            AddBin_D((int)min, (int)max);
            //AddData_To_Hist();
            AddData_To_Hist_Relative_D();
        }

    }

    public void AddStopWatchVal(float val)
    {
        watchTimes.Add(val);
        data_Points.Add(val);
        startHistogram(0);
    }

    void AddValuesToCategories()
    {

        for (int i = 0; i < mEntries.Count; i++)
        {
            mEntries[i].Interval += UnityEngine.Random.Range(-0.3f, 0.3f);
        }
    }

    void Make_Interval_C(double min, double max)
    {
        
        double range = max - min;
        double bin_range = range / bin_count;
        double temp = bin_range;
        frequencyVal = bin_range;
        //print("testing interval outside");
        for (int i = 0; i < bin_count; i++)
        {
            //print("testing interval inside");
            
            interval_Array.Add(bin_range + min);
            bin_range += temp; //counter
        }
    }

    void Make_Interval_D(int min, int max)
    {

        int range = max - min + 1;
        //min = 7; //FOR TESTING --------------
        //print("testing interval outside");
        for (int i = 0; i < range + 1; i++)
        {
            interval_Array.Add(i + min);
            
        }
    }

    void AddBin_C() //add new bins
    {
        double temp = frequencyVal + min;
        for(int i = 0; i < bin_count; i++)
        {
            //print("inside for adding bins");
            double tempMax = temp + frequencyVal;             
            string categoryName =  temp.ToString("F2") + "-" + tempMax.ToString("F2");
            mEntries.Add(new RunChartEntry(categoryName, 0, null));
            Material mat = new Material(SourceMaterial);
            mat.color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );
            var bar = GetComponent<BarChart>();
            bar.DataSource.AddCategory(categoryName, mat);
            temp += frequencyVal;

        }
        setRatio();
    }

    void AddBin_D(int min, int max) //add new discrete bins
    {
        int range = max - min;
        //for (int i = 0; i < range; i++)
        for (int i = 0; i < range + 1; i++)
        {
            int temp = i + min;
            string categoryName = temp.ToString();
            mEntries.Add(new RunChartEntry(categoryName, 0, null));
            Material mat = new Material(SourceMaterial);
            mat.color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );
            var bar = GetComponent<BarChart>();
            bar.DataSource.AddCategory(categoryName, mat);
        }
        setRatio();

        
    }

    public void AddData_To_Hist()
    {
        for(int j = 0; j < data_Points.Count; j++) //cycle through all data points
        {
           
            bool Lock = false;
            for (int i = 0; i < interval_Array.Count; i++) //for each data point, check for its bin
            {
                //print("data: " + data_Points[j]);
                //go through and check if it is less than, then put in that bar[i]
                //print(data_Points[j] + "--" + interval_Array[i]);
                if (data_Points[j] < interval_Array[i] && Lock == false)
                {
                    mEntries[i].Interval += 1;
                    //print("Data ( " + data_Points[j] + ") goes into interval: " + i + " ( " + interval_Array[i] + " )" + ", mEntries: " + mEntries[i].Interval);
                    Lock = true;
                }
                //else
                //mEntries[mEntries.Count - 1].Interval += 1;

            }
        }
        
        
        
        
    }

    public void AddData_To_Hist_Relative_C() //
    {
        for (int j = 0; j < data_Points.Count; j++) //cycle through all data points
        {

            bool Lock = false;
            for (int i = 0; i < interval_Array.Count; i++) //for each data point, check for its bin
            {
                //print("data: " + data_Points[j]);
                //go through and check if it is less than, then put in that bar[i]
                //print(data_Points[j] + "--" + interval_Array[i]);
                if (data_Points[j] < interval_Array[i] && Lock == false)
                {
                    double temp = mEntries[i].Interval; 
                    double tally = data_Points.Count * temp; //tally of items in bin (% times total = number of items in bin)
                    
                    mEntries[i].Interval = (tally + 1) / data_Points.Count;
                    //print("Data ( " + data_Points[j] + ") goes into interval: " + i + " ( " + interval_Array[i] + " )" + ", mEntries: " + mEntries[i].Interval);
                    Lock = true;
                }
                //else
                //mEntries[mEntries.Count - 1].Interval += 1;

            }
        }
    }

    public void AddData_To_Hist_Relative_D() //
    {
        for (int j = 0; j < data_Points.Count; j++) //cycle through all data points
        {

            bool Lock = false;
            for (int i = 0; i < interval_Array.Count; i++) //for each data point, check for its bin
            {
                //print("data: " + data_Points[j]);
                //go through and check if it is less than, then put in that bar[i]
                //print(data_Points[j] + "--" + interval_Array[i]);
               
                if (data_Points[j] == interval_Array[i] && Lock == false)
                {
                    double temp = mEntries[i].Interval;
                    double tally = data_Points.Count * temp; //tally of items in bin (% times total = number of items in bin)

                    mEntries[i].Interval = (tally + 1) / data_Points.Count;
                    //print("Data ( " + data_Points[j] + ") goes into interval: " + i + " ( " + interval_Array[i] + " )" + ", mEntries: " + mEntries[i].Interval);
                    Lock = true;
                }
                //else
                //mEntries[mEntries.Count - 1].Interval += 1;

            }
        }
    }

    public void setRatio()
    {
        //print("here");
        if (interval_Array.Count > 80)
        {
            this.GetComponent<CanvasBarChart>().setRatio(2500);
        }
        else if (interval_Array.Count > 20)
        {
            this.GetComponent<CanvasBarChart>().setRatio(950);
        }
        else if(interval_Array.Count > 12)
        {
            this.GetComponent<CanvasBarChart>().setRatio(700);
        }
        else if (interval_Array.Count > 8)
        {
            //print("ration should have been set");
            this.GetComponent<CanvasBarChart>().setRatio(600);
        }
        if(interval_Array.Count < 8)
        {
            this.GetComponent<CanvasBarChart>().setRatio(226.2f);
        }
         // call function when the # of bins is calculated, and then make simple equation here in stead
        //that will simply pull in number of bins, and multply for value. Test this way first
    }


    //set the specific data. called from buttons on histogram
    public void setExp()
    {
        runExp = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Exponential";
    }
    public void setUni()
    {
        runUni = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Uniform";
    }
    public void setTri()
    {
        runTri = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Triangle";
    }
    public void setPoi()
    {
        runExp = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Poisson";
    }
    public void setDisUni()
    {
        runDisUni = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Uniform";
    }
    public void setBin()
    {
        runBin = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Binomial";
    }
    public void setDis()
    {
        runSimulationD = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Discrete";
    }
    public void setCon()
    {
        runSimulationC = true;
        title.GetComponent<Text>().text = "Distribution of Drill Spawns Continuous";
    }

    public void addData(float data)
    {
        data_Points.Add(data);
        totalDataPoints++;
    }

    public void addDiscreteData(float data)
    {
        discrete_data_Points.Add(data);
    }

    public void Clear()
    {
        switchTimeCounter = switchTime;
        var bar = GetComponent<BarChart>();
        bar.TransitionTimeBetaFeature = switchTime;
        bar.DataSource.ClearCategories();
        bar.DataSource.ClearGroups();
        bar.DataSource.AddGroup("Default");
        data_Points.Clear();
        interval_Array.Clear();
        mEntries.Clear();
    }

    public void ClearTest()
    {
        switchTimeCounter = switchTime;
        var bar = GetComponent<BarChart>();
        bar.TransitionTimeBetaFeature = switchTime;
        bar.DataSource.ClearCategories();
        bar.DataSource.ClearGroups();
        bar.DataSource.AddGroup("Default");
        //data_Points.Clear();
        interval_Array.Clear();
        mEntries.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        if(runExp == true)
        {
            Clear();
            runExp = false;
            startHistogram(0);
        }
        if (runUni == true)
        {
            Clear();
            runUni = false;
            startHistogram(1);
        }
        if (runTri == true)
        {
            Clear();
            runTri = false;
            startHistogram(2);
        }

        if (runPoi == true)
        {
            Clear();
            runPoi = false;
            startHistogram(3);
        }

        if (runDisUni == true)
        {
            Clear();
            runDisUni = false;
            startHistogram(4);
        }

        if (runBin == true)
        {
            Clear();
            runBin = false;
            startHistogram(5);
        }

        if (runSimulationC == true)
        {
            //Clear();
            switchTimeCounter = switchTime;
            var bar = GetComponent<BarChart>();
            bar.TransitionTimeBetaFeature = switchTime;
            bar.DataSource.ClearCategories();
            bar.DataSource.ClearGroups();
            bar.DataSource.AddGroup("Default");
            interval_Array.Clear();
            mEntries.Clear();
            runSimulationC = false;
            startHistogram(6);
        }

        if (runSimulationD == true)
        {
            //Clear();
            switchTimeCounter = switchTime;
            var bar = GetComponent<BarChart>();
            bar.TransitionTimeBetaFeature = switchTime;
            bar.DataSource.ClearCategories();
            bar.DataSource.ClearGroups();
            bar.DataSource.AddGroup("Default");
            interval_Array.Clear();
            mEntries.Clear();
            runSimulationD = false;
            startHistogram(6); //running same as continuous currently
        }

        // changes are timed 
        switchTimeCounter -= Time.deltaTime;
        if (switchTimeCounter < 0f)
        {
            switchTimeCounter = switchTime;
            var bar = GetComponent<BarChart>();
            //position the categories according to the currently displayed values
            for (int i = 0; i < mEntries.Count; i++)
            {
                bar.DataSource.MoveCategory(mEntries[i].Name, i);
            }
            //AddBin(UnityEngine.Random.Range(0f, 100f));
            //AddBin(UnityEngine.Random.Range(0f, 100f));
            //AddBin(UnityEngine.Random.Range(0f, 100f));
            //AddDataPoint(10.1f);
            //AddDataPoint(15.1f);
            //AddDataPoint(5.1f);
            
            // add the changes
            //AddValuesToCategories();


            // sort the changes
            //mEntries.Sort((x, y) => (int)Math.Sign(x.Interval - y.Interval));


            // animate the transition to the next values
            for (int i = 0; i < mEntries.Count; i++)
            {

                bar.DataSource.SlideValue(mEntries[i].Name, "Default", mEntries[i].Interval, switchTime);
            }

        }
    }
}
