using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BinButton : MonoBehaviour
{
    //what changes with button?
    public Text binText;
    public GameObject histogram;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        binText.text = histogram.GetComponent<Histogram_Graphing>().bin_count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.name == "Down_Button_Bins" && histogram.GetComponent<Histogram_Graphing>().bin_count > 4)
        {
            histogram.GetComponent<Histogram_Graphing>().bin_count--;
        }
        if (this.name == "Up_Button_Bins" && histogram.GetComponent<Histogram_Graphing>().bin_count < 10)
        {
            histogram.GetComponent<Histogram_Graphing>().bin_count++;

        }


        this.GetComponentInParent<Image>().color = Color.cyan;
        
        Invoke("MakeAvail", 0.5f);
    }

    public void TriggerButton()
    {
        if (this.name == "Down_Button_Bins" && histogram.GetComponent<Histogram_Graphing>().bin_count > 4)
        {
            histogram.GetComponent<Histogram_Graphing>().bin_count--;
        }
        if (this.name == "Up_Button_Bins" && histogram.GetComponent<Histogram_Graphing>().bin_count < 10)
        {
            histogram.GetComponent<Histogram_Graphing>().bin_count++;

        }


        this.GetComponentInParent<Image>().color = Color.cyan;

        Invoke("MakeAvail", 0.5f);
    }
    private void MakeAvail()
    {
        this.GetComponentInParent<Image>().color = Color.white;
    }
}
