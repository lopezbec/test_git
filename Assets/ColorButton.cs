using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    
    public GameObject IEE322;
    public GameObject IEE323;
    public GameObject Settings;
    public GameObject Viewingroom;
    public GameObject FactoryFloor;
    public GameObject Walking;
    public GameObject Teleporting;
    public GameObject Back;

    public GameObject one;
    public GameObject two;
    public GameObject zero;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject enter;
    public GameObject decima;
    public GameObject delete;
    public GameObject clear;
    public GameObject equal;
    public GameObject add;
    public GameObject subtract;
    public GameObject divide;
    public GameObject multiply;
    public GameObject calculator;
    public GameObject submission;

    public bool MeanButto;
    public bool ModeButto;
    public bool MedianButto;
    public bool VarianceButto;
    public bool DiscreteButto;
    public bool ContinuousButto;

    public bool IEE32;
    public bool IEE33;
    public bool Setting;
    public bool Viewingroo;
    public bool FactoryFloo;
    public bool Walkin;
    public bool Teleportin;
    public bool Bac;

    public bool on;
    public bool tw;
    public bool zer;
    public bool thre;
    public bool fou;
    public bool fiv;
    public bool si;
    public bool seve;
    public bool eigh;
    public bool nin;
    public bool ente;
    public bool decim;
    public bool delet;
    public bool clea;
    public bool equa;
    public bool ad;
    public bool subtrac;
    public bool divid;
    public bool multipl;
    public bool calculato;
    public bool submissio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        //Wrist Buttons
        if (IEE32 == true)
        {
            IEE322.GetComponent<Image>().color = Color.cyan;
        }
        if (IEE33 == true)
        {
            IEE323.GetComponent<Image>().color = Color.cyan;
        }
        if (Setting == true)
        {
            Settings.GetComponent<Image>().color = Color.cyan;
        }
        if (Viewingroo == true)
        {
            Viewingroom.GetComponent<Image>().color = Color.cyan;
        }
        if (FactoryFloo == true)
        {
            FactoryFloor.GetComponent<Image>().color = Color.cyan;
        }
        if (Walkin == true)
        {
            Walking.GetComponent<Image>().color = Color.cyan;
        }
        if (Teleportin == true)
        {
            Teleporting.GetComponent<Image>().color = Color.cyan;
        }
        if (Setting == true)
        {
            Settings.GetComponent<Image>().color = Color.cyan;
        }
        if (Bac == true)
        {
            Back.GetComponent<Image>().color = Color.cyan;
        }

        //Calculator Buttons
        if (on == true)
        {
            one.GetComponent<Image>().color = Color.cyan;
        }
        if (tw == true)
        {
            two.GetComponent<Image>().color = Color.cyan;
        }
        if (zer == true)
        {
            zero.GetComponent<Image>().color = Color.cyan;
        }
        if (thre == true)
        {
            three.GetComponent<Image>().color = Color.cyan;
        }
        if (fou == true)
        {
            four.GetComponent<Image>().color = Color.cyan;
        }
        if (fiv == true)
        {
            five.GetComponent<Image>().color = Color.cyan;
        }
        if (si == true)
        {
            six.GetComponent<Image>().color = Color.cyan;
        }
        if (seve == true)
        {
            seven.GetComponent<Image>().color = Color.cyan;
        }
        if (eigh == true)
        {
            eight.GetComponent<Image>().color = Color.cyan;
        }
        if (nin == true)
        {
            nine.GetComponent<Image>().color = Color.cyan;
        }
        if (ente == true)
        {
            enter.GetComponent<Image>().color = Color.cyan;
        }
        if (decim == true)
        {
            decima.GetComponent<Image>().color = Color.cyan;
        }
        if (delet == true)
        {
            delete.GetComponent<Image>().color = Color.cyan;
        }
        if (clea == true)
        {
            clear.GetComponent<Image>().color = Color.cyan;
        }
        if (equa == true)
        {
            equal.GetComponent<Image>().color = Color.cyan;
        }
        if (ad == true)
        {
            add.GetComponent<Image>().color = Color.cyan;
        }
        if (subtrac == true)
        {
            subtract.GetComponent<Image>().color = Color.cyan;
        }
        if (multipl == true)
        {
            multiply.GetComponent<Image>().color = Color.cyan;
        }
        if (divid == true)
        {
            divide.GetComponent<Image>().color = Color.cyan;
        }



    }

    private void OnTriggerExit(Collider other)
    {
        
            IEE322.GetComponent<Image>().color = Color.white;
            IEE323.GetComponent<Image>().color = Color.white;
            Settings.GetComponent<Image>().color = Color.white;
            Viewingroom.GetComponent<Image>().color = Color.white;
            FactoryFloor.GetComponent<Image>().color = Color.white;
            Walking.GetComponent<Image>().color = Color.white;
            Teleporting.GetComponent<Image>().color = Color.white;
            Settings.GetComponent<Image>().color = Color.white;
            Back.GetComponent<Image>().color = Color.white;
            one.GetComponent<Image>().color = Color.white;
            two.GetComponent<Image>().color = Color.white;
            zero.GetComponent<Image>().color = Color.white;
            three.GetComponent<Image>().color = Color.white;
            four.GetComponent<Image>().color = Color.white;
            five.GetComponent<Image>().color = Color.white;
            six.GetComponent<Image>().color = Color.white;
            seven.GetComponent<Image>().color = Color.white;
            eight.GetComponent<Image>().color = Color.white;
            nine.GetComponent<Image>().color = Color.white;
            enter.GetComponent<Image>().color = Color.white;
            decima.GetComponent<Image>().color = Color.white;
            delete.GetComponent<Image>().color = Color.white;
            clear.GetComponent<Image>().color = Color.white;
            equal.GetComponent<Image>().color = Color.white;
            add.GetComponent<Image>().color = Color.white;
            subtract.GetComponent<Image>().color = Color.white;
            multiply.GetComponent<Image>().color = Color.white;
            divide.GetComponent<Image>().color = Color.white;
            calculator.GetComponent<Image>().color = Color.white;
            submission.GetComponent<Image>().color = Color.white;
    }

}
