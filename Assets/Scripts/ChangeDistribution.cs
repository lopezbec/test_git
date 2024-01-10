using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDistribution : MonoBehaviour
{
    public GameObject distrButton0;//three buttons.  One highlighted at a time
    //button highlighted is which distribution the basic spawner uses\
    public GameObject distrButton0Parent;
    public GameObject distrButton1;
    public GameObject distrButton2;
    public GameObject histogram; //needs to be cleared with change of distribution
    

    //private int currNum; //keeps track of which button is active, and switches this with the new active
    public GameObject spawner;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        //spawner.GetComponent<BasicSpawner>().;
        active = false;
        if (distrButton0.name.Equals("Exponential") || distrButton0.name.Equals("Poisson"))
        {
            active = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        string distCurrentC = spawner.GetComponent<BasicSpawner>().getDistTypeC();
        string distCurrentD = spawner.GetComponent<BasicSpawner>().getDistTypeD();
        //print("Distribution curreent: " + distCurrentC);
        print("Distribution button: " + distrButton0.name);
        //print("testing: " + distrButton0Parent);
        if(distrButton0.name == distCurrentC || distrButton0.name == distCurrentD)
        {
            distrButton0Parent.GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            distrButton0Parent.GetComponent<Image>().color = Color.white;
        }
        //if (distrButton1.GetComponent<ChangeDistribution>().active || distrButton2.GetComponent<ChangeDistribution>().active)
        //{
         //   distrButton0.GetComponent<ChangeDistribution>().active = false;
        //}
        /*
        if (distrButton0.GetComponent<ChangeDistribution>().active)
        {
            distrButton0Parent.GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            distrButton0Parent.GetComponent<Image>().color = Color.white;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("these are in fact being collided with");
        //print("knows it is the finger");
        //if (!(distrButton0.GetComponent<ChangeDistribution>().active))
        //{
        //    print("changes values of active button bools");
        //    distrButton0.GetComponent<ChangeDistribution>().active = true;
        //    distrButton1.GetComponent<ChangeDistribution>().active = false;
        //    distrButton2.GetComponent<ChangeDistribution>().active = false;
        //

        if (distrButton0.name.Equals("Exponential"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent0();
            print("exp");
        }
        if (distrButton0.name.Equals("Continuous"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent1();
            print("cnt");
        }
        if (distrButton0.name.Equals("Triangular"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent2();
        }
        if (distrButton0.name.Equals("Poisson"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent0();
            print("poisson");
        }
        if (distrButton0.name.Equals("Discrete"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent1();
        }
        if (distrButton0.name.Equals("Binomial"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent2();
        }

    }

    public void TriggerButton()
    {
        if (distrButton0.name.Equals("Exponential"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent0();
            print("exp");
        }
        if (distrButton0.name.Equals("Continuous"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent1();
            print("cnt");
        }
        if (distrButton0.name.Equals("Triangular"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrProductionRateCurrent2();
        }
        if (distrButton0.name.Equals("Poisson"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent0();
            print("poisson");
        }
        if (distrButton0.name.Equals("Discrete"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent1();
        }
        if (distrButton0.name.Equals("Binomial"))
        {
            spawner.GetComponent<BasicSpawner>().changetypeDistrDefectCurrent2();
        }
        if(histogram.gameObject != null)
        {
            histogram.GetComponent<Histogram_Graphing>().Clear();

        }

    }
}
