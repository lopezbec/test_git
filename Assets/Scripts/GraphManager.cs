using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GraphManager : MonoBehaviour
{
    public static double solution;
    public double test = 1.2;
    //keep track of each data set seperately
    public List<float> calcvalues = new List<float>();
    public List<float> watchvalues = new List<float>();
    public List<float> automaticSampleValues = new List<float>(); //only automaticSampleValues and values are used currently
    public GameObject DataPointObject; //prefab game object image used .3to plot individual data points
    
    public GameObject MeanTextObj;
    //private Text MeanText;
    //private Text RangeText;
    //private Text VarianceText;

    private GameObject DataText; //refers to the dropdown menu that provides different data sets to display

    public List<float> values = new List<float>(); //list of all values currently on graph
    private float maxvalue = -1 / 0f;
    private float minvalue = 1 / 0f;

    private float maxvalue2 = -1 / 0f;
    private float minvalue2 = 1 / 0f;

    private float maxvalue3 = -1 / 0f;
    private float minvalue3 = 1 / 0f;

    //IMPORTANT below is the dataoption to make stopwatch work again
    private int DataOption = 2; //which data producing tool is being displayed on the graph

    public static int levelSelection;

    private List<GameObject> points = new List<GameObject>(); //list of all current data points

    //gameobject of mean, if it is active, then values are integers
    public GameObject meanObject;
    //initialize the drawing of the graph
    void Start()
    {
        DataText = GameObject.Find("DataText");
        //MeanText = MeanTextObj.GetComponent<Text>();

        
        //RangeText = GameObject.Find("RangeText").GetComponent<Text>();
        //VarianceText = GameObject.Find("VarianceText").GetComponent<Text>();
        Plot();
    }


    //Called by external tools, adds a new data point and replots the graph
    public void Addcalc(float value) // not in use
    {
        if (value > maxvalue)
            maxvalue = value;
        if (value < minvalue)
            minvalue = value;
        calcvalues.Add(value);
        Plot();
    }
    public void Addwatch(int value) //not in use
    {
        /*  original code being, testing a combination with addsample
        if (value > maxvalue2)
            maxvalue2 = value;
        if (value < minvalue2)
            minvalue2 = value;
        watchvalues.Add(value);
        Plot();
        */
        if (value > maxvalue3)
            maxvalue3 = value;
        if (value < minvalue3)
            minvalue3 = value;
        automaticSampleValues.Add(value);
        Plot();
    }
    public void AddSample(float value) //from instructions page samples (tablet samples button)
    {
        /*
        print("val " + value);
        if(values.Count < 10)
        {
            if (value > maxvalue3)
                maxvalue3 = value;
            if (value < minvalue3)
                minvalue3 = value;
            if (meanObject.activeInHierarchy)
            {
                automaticSampleValues.Add((int)value);
                Plot();
            }
            else
            {
                automaticSampleValues.Add(value);
                Plot();
            }
            
        }
        */
        if (value > maxvalue3)
            maxvalue3 = value;
        if (value < minvalue3)
            minvalue3 = value;
        automaticSampleValues.Add(value);
        Plot();
    }
    //resets values and clears graph 
    public void Clear() //***********need to wipe the value in other script**********************************
    {

        if (DataOption == 0)
        {
            calcvalues.Clear(); //first clear the values
            maxvalue = -1 / 0f;
            minvalue = 1 / 0f;
        }
        if (DataOption == 1)
        {
            watchvalues.Clear();
            maxvalue2 = -1 / 0f;
            minvalue2 = 1 / 0f;
        }
        if (DataOption == 2) //dataoption 2 is the only one in use currently, and combines both watches and sample
        {
           
            automaticSampleValues.Clear();
            maxvalue3 = -1 / 0f;
            minvalue3 = 1 / 0f;
        }

        BroadcastMessage("Destroy");
        points.Clear();
        points.TrimExcess();
        Plot(); //redraw blank graph
        solution = 0;//clears the solution

    }


    //takes the data points and properly scales the axes then draws the points on a graph
    void Plot()
    {
        if (values.Count < 11)
        {
            //max and min of the data that is being displayed
            float max = 0f;
            float min = 0f;

            //display the data for each given tool
            if (DataOption == 0)
            {
                values = calcvalues;
                DataText.GetComponent<Text>().text = "Calculator";
                max = maxvalue;
                min = minvalue;
            }

            if (DataOption == 1)
            {

                values = watchvalues;
                DataText.GetComponent<Text>().text = "Stop Watch";
                max = maxvalue2;
                min = minvalue2;
            }

            if (DataOption == 2)
            {
                automaticSampleValues.AddRange(watchvalues);
                values = automaticSampleValues;
                //DataText.GetComponent<Text>().text = "Stop Watch & Automatic";
                max = maxvalue3;
                min = minvalue3;
            }


            //starting coordinates (bottom left corner) of the graph
            float xstart = -395f;
            float ystart = -230f;
            //the full length of available plotting space in each dimension on the graph
            float xlength = 790f;
            float ylength = 460f;

            //the scaling factor to multiply by the overall length that gives the total displacement from 0
            float xscale, yscale;
            //the range of the actual data points
            float range = max - min; //list is sorted, range = last entry - first entry
                                     //the final x and y coordinates calculated for proper placement on the canvas
            float x, y;

            //used to calculate mean and variance
            float sum = 0;
            //float variance = 0.0f;

            //clear previous data drawings
            BroadcastMessage("Destroy");
            points.Clear();
            points.TrimExcess();

            GameObject newpoint; //points to the latest data point to be drawn
            int i;
            for (i = 0; i < values.Count; i++)
            { //dynamically plot dots and also print statistical values (mean, median, etc.)
                
                sum += values[i];
                xscale = (float)i / (float)(values.Count - 1); //which numbered data point is this?
                yscale = (values[i] - min) / range; //where does this point lay in reference to the range of values?

                //calculate final coordinates
                x = xscale * xlength + xstart;
                y = yscale * ylength + ystart;

                /*
                Debug.Log("Value: " + values[i].ToString());
                Debug.Log("Max: " + maxvalue.ToString());
                Debug.Log("Min: " + minvalue.ToString());
                Debug.Log("Range:" + range.ToString());
                Debug.Log("Xscale: " + xscale.ToString());
                Debug.Log("Yscale: " + yscale.ToString());
                Debug.Log("X: " + x.ToString());
                Debug.Log("Y: " + y.ToString());
                */

                //create the point and properly place it on the graph
                newpoint = Instantiate(DataPointObject, gameObject.transform);
                newpoint.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0f);
                newpoint.GetComponentInChildren<Text>().text = values[i].ToString("0.00");
                newpoint.GetComponent<GraphPointTrigger>().setIndex(i);

                points.Add(newpoint);
                
                

            }

            //updates statistical display info
            //RangeText.text = "Range: " + range.ToString("0.00");

            //Debug.Log("reached plot");



            //VarianceText.text = "Std Dev: " + StandDev().ToString("0.00"); //puts std dev on graph now
        }


    }

    //calculates standard deviation
    public double StandDev()
    {
        double ret = 0;
        if (values.Count > 0)
        {
            //Compute the Average      
            double total = 0;
            double mean = Mean();
            for (int i = 0; i < values.Count; i++)
            {
                total = values[i] - mean;
            }
            ret = System.Math.Sqrt(total / values.Count);
        }
        return ret;
    }

    public double Variance()
    {
        //return System.Math.Pow(StandDev(), 2);
        float varianceTemp = 0;
        float sum = 0;
        for (int i = 0; i < values.Count; i++)
        {
            float step1 = values[i] - Mean();
            float step2 = step1 * step1;
            sum += step2;
            //varianceTable.text += "\nx" + i + " = " + step1 + "^2 = " + step2;
            //varianceTemp
        }
        varianceTemp = sum / (values.Count - 1);
        return varianceTemp;
    }

        public double Sum()
    {
        double sum = 0;
        for (int i = 0; i < values.Count; i++)
        { //dynamically plot dots and also print statistical values (mean, median, etc.)
            sum += values[i];
        }
        return sum;
    }

    //calculates mean
    public float Mean()
    {
        solution = (float)(Sum() / values.Count);
        return (float)solution;
    }


    //calculates median
    float median, mode, lastVal, curCount = 0, maxCount = 0;
    int count;
    List<float> temp = new List<float>();

    public int Median()
    {
        count = values.Count;
        temp = values;
        temp.Sort();
        if (count < 2)
        {

        }
        else if (count % 2 == 0)
            median = temp[count / 2];
        else
            median = (temp[count / 2] + temp[count / 2 + 1]) / 2;
        solution = median;
        return (int)solution;
        
    }

    //calculates mode
    public double Mode()
    {
        count = watchvalues.Count;
        temp = watchvalues;
        temp.Sort();

        for (int i = 0; i < count; i++)
        {
            lastVal = temp[i];
            if (lastVal != temp[i + 1] && i + 1 != count)
            {
                lastVal = temp[i + 1];
                if (curCount > maxCount)
                {
                    maxCount = curCount;
                    mode = lastVal;
                }
            }
            curCount++;
        }

        solution = 1;
        return (int)solution;
    }

    //cycles through all available data source options to display on the graph
    public void CycleValues()
    {
        DataOption++;
        if (DataOption > 1)
            DataOption = 0;
        Plot();
    }

    void Update()
    {
        if (levelSelection == 0)
        {
            //MeanText.text = "Mean: " + Mean().ToString("0.00");
        }
        else if (levelSelection == 1)
        {
            //MeanText.text = "Median: " + Median().ToString("0.00");
        }
        else if (levelSelection == 2)
        {
            //MeanText.text = "Mode: " + Mode().ToString("0.00");
        }

        
    }

    public void removePoint(int index) //removes specific point that was tapped in scene
    {
        values.RemoveAt(index);
        Plot();
    }

    public void undoLastPoint(){
        removePoint(values.Count - 1);
    }

    public void Sort() //sorts values in values list
    {
        values.Sort();
        //sampleObject is the samplebutton on the tablet, which connects to the board for sample problems
        GameObject sampleObject = GameObject.Find("SampleButton");
        sampleObject.GetComponent<Sample>().ListUpdate();
    }

    public void clearPoints() //deletes all points in values
    {
        values.Clear();
        Plot();
        GameObject sampleObject = GameObject.Find("SampleButton");
        sampleObject.GetComponent<Sample>().ListUpdate();
    }
}