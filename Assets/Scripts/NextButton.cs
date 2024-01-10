using UnityEngine;

public class NextButton : MonoBehaviour
{
    public bool mean1;
    public bool mean2;
    public bool mean3;
    public bool contin1;
    public bool contin2;
    public bool contin3;
    public bool discrete1;
    public bool discrete2;
    public bool discrete3;

    public GameObject ContinuousText;
    public GameObject ContinuousText2;
    public GameObject ContinuousText3;
    public GameObject DiscreteText;
    public GameObject DiscreteText2;
    public GameObject DiscreteText3;
    public GameObject MeanText;
    public GameObject MeanText2;
    public GameObject MedianText;
    public GameObject ModeText;
    public GameObject VarianceText;
    public GameObject InstructionsGeneral;
    public GameObject HelpInstr;

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
        if(contin1 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(true);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if(contin2 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(true);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (contin3 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (discrete1 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(true);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (discrete2 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(true);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (discrete3 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(false);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (mean1 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(true);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

        if (mean2 == true)
        {
            MedianText.SetActive(false);
            MeanText.SetActive(false);
            MeanText2.SetActive(true);
            ModeText.SetActive(false);
            ContinuousText.SetActive(false);
            ContinuousText2.SetActive(false);
            ContinuousText3.SetActive(false);
            DiscreteText.SetActive(false);
            DiscreteText2.SetActive(false);
            DiscreteText3.SetActive(false);
            VarianceText.SetActive(false);
            InstructionsGeneral.SetActive(false);
            HelpInstr.SetActive(false);
        }

    }
}
