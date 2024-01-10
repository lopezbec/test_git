﻿using UnityEngine;
using UnityEngine.UI;

public class MeanButton : MonoBehaviour
{
    public Text ModuleText;
    public GameObject ContinuousText;
    public GameObject ContinuousText2;
    public GameObject ContinuousText3;
    public GameObject ContinuousText4;
    public GameObject DiscreteText;
    public GameObject DiscreteText2;
    public GameObject DiscreteText3;
    public GameObject DiscreteText4;
    public GameObject MeanText;
    public GameObject MeanText2;
    public GameObject MedianText;
    public GameObject ModeText;
    public GameObject VarianceText;
    public GameObject BeginningInstructions;
    // Start is called before the first frame update
    void Start()
    {
        BeginningInstructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ModuleText.text = " Mean ";
        MedianText.SetActive(false);
        MeanText.SetActive(true);
        MeanText2.SetActive(false);
        ModeText.SetActive(false);
        ContinuousText.SetActive(false);
        ContinuousText2.SetActive(false);
        ContinuousText3.SetActive(false);
        ContinuousText4.SetActive(false);
        DiscreteText.SetActive(false);
        DiscreteText2.SetActive(false);
        DiscreteText3.SetActive(false);
        DiscreteText4.SetActive(false);
        VarianceText.SetActive(false);
        BeginningInstructions.SetActive(true);
    }
}