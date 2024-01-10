using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram_Button : MonoBehaviour
{
    public GameObject Histogram;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerButton(){
        if (this.name.Equals("Exponential_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setExp();
        }
        else if (this.name.Equals("Uniform_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setUni();
        }
        else if (this.name.Equals("Triangle_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setTri();
        }
        else if (this.name.Equals("Poisson_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setPoi();
        }
        else if (this.name.Equals("Discrete_Uniform_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setDisUni();
        }
        else if (this.name.Equals("Binomial_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setBin();
        }
        else if (this.name.Equals("Discrete_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setDis();
        }
        else if (this.name.Equals("Continuous_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setCon();
        }
        else if (this.name.Equals("ClearButton"))
        {
            Histogram.GetComponent<Histogram_Graphing>().Clear();
        }
        else
        {
            print("error");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.name.Equals("Exponential_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setExp();
        }
        else if (this.name.Equals("Uniform_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setUni();
        }
        else if (this.name.Equals("Triangle_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setTri();
        }
        else if (this.name.Equals("Poisson_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setPoi();
        }
        else if (this.name.Equals("Discrete_Uniform_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setDisUni();
        }
        else if (this.name.Equals("Binomial_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setBin();
        }
        else if (this.name.Equals("Discrete_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setDis();
        }
        else if (this.name.Equals("Continuous_Button"))
        {
            Histogram.GetComponent<Histogram_Graphing>().setCon();
        }
        else if (this.name.Equals("ClearButton"))
        {
            Histogram.GetComponent<Histogram_Graphing>().Clear();
        }
        else
        {
            print("error");
        }



    }
}
