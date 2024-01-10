using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Accord.Statistics.Distributions.Univariate;
using System.Threading;

public class BasicSpawner : MonoBehaviour
{

    //Objects
    public GameObject[] SpawnItem; //item to spawn-right
    public GameObject[] DefectItem; //defect to spawn

    //Lists
    public List<GameObject> Defectives; //List of defective GameObject variants

    // Arrays for types of distributions
    private string[] productionRatedistrTypesArr = { "Exponential", "Continuous", "Triangular" };
    private string[] defectDistrTypesArr = { "Poisson", "Discrete Uniform", "Binomial" };


    //Variables
    public double productionRateCurrent = 750; //per hour (min 500, max 1000)
    public double defectChanceCurrent = 0.05; //0 for no chance, 1 for 100% chance
    private int paramaterShift = 50;  //for max/min values in uniform
    private double numPartsCurrent = 2;
    private double productionRateGen;
    private double cumulGen;
    private int sampledRate;
    private int defectRateCurrent;
    private double productionTime = 0;
    int defectRate;

    public string typeDistrProductionRateCurrent;
    private string typeDistrDefectCurrent;

    private float time = 0; //time since last spawn


    public GameObject partDetection;

    void Start()
    {
        typeDistrProductionRateCurrent = productionRatedistrTypesArr[0];
        //typeDistrProductionRateCurrent = productionRatedistrTypesArr[1];
        //typeDistrProductionRateCurrent = productionRatedistrTypesArr[2];
        typeDistrDefectCurrent = defectDistrTypesArr[0];


    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //keeps track of time passed per frame

        //--------------------TBS conditionals-----------------------------------------------------------------
        //Exponential Takes a rate and generates a time 

        if (typeDistrProductionRateCurrent == productionRatedistrTypesArr[0])
        {
            var ed = new ExponentialDistribution(rate: productionRateCurrent);
            //Do generate if the time is greater than 
            double productionRateGen = ed.Generate();
            
            if (time <= productionTime)
            {

            }
            else
            {
                productionTime = productionRateGen * 3600;
            }
        }

        if (typeDistrProductionRateCurrent == productionRatedistrTypesArr[1])
        {
            print("uniform");
            //productionRateCurrent -5 and +5
            double MinValue = productionRateCurrent - paramaterShift; //production rate - num
            double MaxValue = productionRateCurrent + paramaterShift; //production rate + num
            var ucd = new UniformContinuousDistribution(MinValue, MaxValue);
            double productionRateGen = ucd.Generate();
            //print("prod. rate gen = " + productionRateGen);
            //print("production time = " + productionTime);
            //print("time = " + time);
            if (time <= productionTime)
            {

            }
            else
            {
                productionTime = (1/productionRateGen) * 3600;
            }
        }

        if (typeDistrProductionRateCurrent == productionRatedistrTypesArr[2])
        {
            //productionRateCurrent -5 and +5 for min and max
            double MinValue = productionRateCurrent - paramaterShift; //production rate - num
            double MaxValue = productionRateCurrent + paramaterShift; //production rate + num
            double Mode = productionRateCurrent; //in between min and max
            var trid = new TriangularDistribution(MinValue, MaxValue, Mode);
            double productionRateGen = trid.Generate();
            //print("prod. rate gen = " + productionRateGen);
            //print("production time = " + productionTime);
            //print("time = " + time);
            if (time <= productionTime)
            {

            }
            else
            {
                productionTime = (1/productionRateGen) * 3600;
            }
        }
        // -------------------Defect chance conditionals--------------------------------------------------------

        if (typeDistrDefectCurrent == defectDistrTypesArr[0]) //Poisson if-statement
        {

            var pd = new PoissonDistribution(lambda: (productionRateCurrent));

            defectRateCurrent = pd.InverseDistributionFunction(defectChanceCurrent); // find the defect rate at the defect chance from the second slider 
            

            //print(defectRateCurrent + "    Defect Rate Current");

            //print(defectChanceCurrent + "    Defect Chance Current");

            sampledRate = pd.Generate(); // generate a production rate with each update  



        }

        if (typeDistrDefectCurrent == defectDistrTypesArr[1]) //Uniform if-statement
        {

            int MinValue = Convert.ToInt32(productionRateCurrent) - paramaterShift;
            int MaxValue = Convert.ToInt32(productionRateCurrent) + paramaterShift;
            var udd = new UniformDiscreteDistribution(MinValue, MaxValue);  //declare a Uniform distribution using production rate from first slider and shift variable
            defectRateCurrent = udd.InverseDistributionFunction(defectChanceCurrent);  // find the defect rate at the defect chance from the second slider 


            sampledRate = udd.Generate();


        }

        if (typeDistrDefectCurrent == defectDistrTypesArr[2]) // Binomial if-statement
        {


            var bd = new BinomialDistribution(Convert.ToInt32(productionRateCurrent), defectChanceCurrent);
            defectRateCurrent = bd.InverseDistributionFunction(defectChanceCurrent);


            sampledRate = bd.Generate();


        }


        //---------Spawner for correct parts and conditional for defective parts---------------------------------
        //spawns when time since last spawn has exceeded the TBS generated number

        bool stop_belt = partDetection.GetComponent<PartIncoming>().stopConveyer;//stops production if belt is stopped
        if (time >= productionTime && !stop_belt)
        { // Compares defect chance to randomly generated number and if it is less, it spawns a defective part
            //print("Sampled Rate: " + sampledRate);
            //print("defectRateCurrent: " + defectRateCurrent);
            if (sampledRate >= defectRateCurrent)
            {
                Spawn();
                //print("Time: " + time);
                time = 0;

            }
            else
            {
                Defect();
                time = 0;
            }
            //print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);


        }

    }


    //Instantiates a good part as defined by unity editor window
    public void Spawn()
    {
        for (int i = 1; numPartsCurrent >= i; i = i + 2)
        {
            Instantiate(SpawnItem[0], transform.position, Quaternion.identity);
            Instantiate(SpawnItem[1], transform.position, Quaternion.identity);

        }
    }

    public void Defect()
    {
        for (int i = 1; numPartsCurrent >= i; i = i + 2)
        {
            //Debug.Log("Spawning Defect");
            Instantiate(DefectItem[0], transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(DefectItem[1], transform.position, Quaternion.Euler(0, 90, 0));

        }
    }
    //Spawner canvas and get methods
    public void IncreaseDefectChance()
    {
        if(defectChanceCurrent < 1)
        {
            //print("went up");
            defectChanceCurrent += 0.1;
        }
    }

    public void DecreaseDefectChance()
    {
        if(defectChanceCurrent > 0.1)
        {
            //print("went down");
            defectChanceCurrent -= 0.1;
        }
        if(defectChanceCurrent < 0.1)
        {
            defectChanceCurrent = 0;
        }
    }

    public void IncreasePartSpawn()
    {
        if (numPartsCurrent <= 4)
        {
            //print("part went up");
            numPartsCurrent += 2;
        }
    }

    public void DecreasePartSpawn()
    {
        if (numPartsCurrent >= 4)
        {
            //print("part went down");
            numPartsCurrent -= 2;
        }
    }

    public void IncreaseProductionRate()
    {
        if (productionRateCurrent < 1000)
        {
            productionRateCurrent += 50;
        }
    }

    public void DecreaseProductionRate()
    {
        if(productionRateCurrent > 500)
        {
            productionRateCurrent -= 50;
        }

    }

    public double getNumParts()
    {
        return numPartsCurrent;
    }

    public double getDefectChance()
    {
        return defectChanceCurrent;
    }

    public double getPruductionRate()
    {
        return productionRateCurrent;
    }
    //ChangeDistribution Script methods to manipulate distribution Type for parts&defects
    public void changetypeDistrProductionRateCurrent0()
    {
        typeDistrProductionRateCurrent = productionRatedistrTypesArr[0];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }
    public void changetypeDistrProductionRateCurrent1()
    {
        typeDistrProductionRateCurrent = productionRatedistrTypesArr[1];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }
    public void changetypeDistrProductionRateCurrent2()
    {
        typeDistrProductionRateCurrent = productionRatedistrTypesArr[2];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }
    public void changetypeDistrDefectCurrent0()
    {
        typeDistrDefectCurrent = defectDistrTypesArr[0];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }
    public void changetypeDistrDefectCurrent1()
    {
        typeDistrDefectCurrent = defectDistrTypesArr[1];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }
    public void changetypeDistrDefectCurrent2()
    {
        typeDistrDefectCurrent = defectDistrTypesArr[2];
        print("Batch Size: " + numPartsCurrent + "\n" + "Production Rate: " + productionRateCurrent + "\n" + "Production Distribution Type: " + typeDistrProductionRateCurrent + "\n" + "Defect Distrubtion Type: " + typeDistrDefectCurrent);

    }

    public string getDistTypeC()
    {
        return typeDistrProductionRateCurrent;
    }
    public string getDistTypeD()
    {
        return typeDistrDefectCurrent;
    }

}