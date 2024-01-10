using UnityEngine;
using UnityEngine.UI;


public class DistIntroManager : MonoBehaviour
{
    //audio clip arrays -------------------
    public AudioClip[] meanClips;
    public AudioClip[] medClips;
    public AudioClip[] modeClips;
    public AudioClip[] stdClips;
    public AudioClip[] continuousClips;
    public AudioClip[] discreteClips;
    AudioClip[] clips;
    //-------------------------------------

    //Text files --------------------------
    public TextAsset meanText;
    public TextAsset medText;
    public TextAsset modeText;
    public TextAsset stdText;
    public TextAsset discreteText;
    public TextAsset contText;
    //-------------------------------------

    //Selected Equation String
    private string equation = "";

    //Changing TextAsset based on button choice
    TextAsset textFile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CorrectAnswer").GetComponent<Text>().text = "";
        GameObject.Find("SubmittedAnswer").GetComponent<Text>().text = "";
    }

    //button press methods----------------------------------
    public void ButtonMean()
    {
        clips = meanClips;
        textFile = meanText;
        EnableAllButtons();
        DisableButton("MeanButton");
        GraphManager.levelSelection = 0;
        ChalkManager.levelSelection = 0;
        equation = "MeanEQ";
    }

    public void ButtonMedian()
    {
        clips = medClips;
        textFile = medText;
        EnableAllButtons();
        DisableButton("MedianButton");
        GraphManager.levelSelection = 1;
        ChalkManager.levelSelection = 1;
        equation = "MedianEQ";
    }

    public void ButtonMode()
    {
        clips = modeClips;
        textFile = modeText;
        EnableAllButtons();
        DisableButton("ModeButton");
        GraphManager.levelSelection = 2;
        ChalkManager.levelSelection = 2;
        equation = "ModeEQ";
    }

    public void ButtonStd()
    {
        clips = stdClips;
        textFile = stdText;
        EnableAllButtons();
        DisableButton("StdVarButton");
        equation = "std_dev";
    }

    public void ButtonContinuous()
    {
        clips = continuousClips;
        textFile = contText;
        EnableAllButtons();
        DisableButton("ContinuousButton");
        equation = "";
    }

    public void ButtonDiscrete()
    {
        clips = discreteClips;
        textFile = discreteText;
        EnableAllButtons();
        DisableButton("DiscreteButton");
        equation = "";
    }

    public void ButtonReady()
    {
        DisableEquations();
        if(equation != "")
        {
            GameObject.Find(equation).GetComponent<SpriteRenderer>().enabled = true;
        }

        disableButtons();
        GameObject.Find("Introduction").GetComponent<UniversalInstructionManager>().setAssets(textFile, clips);
    }

    public void EnableAllButtons()
    {
        EnableButton("MeanButton");
        EnableButton("MedianButton");
        EnableButton("ModeButton");
        EnableButton("ContinuousButton");
        EnableButton("DiscreteButton");
        EnableButton("StdVarButton");
        EnableButton("modulereadyup");
    }

    public void resetSelection()
    {
        EnableButton("MeanButton");
        EnableButton("MedianButton");
        EnableButton("ModeButton");
        EnableButton("ContinuousButton");
        EnableButton("DiscreteButton");
        EnableButton("StdVarButton");
        DisableButton("modulereadyup");
    }

    public void disableButtons()
    {
        DisableButton("MeanButton");
        DisableButton("MedianButton");
        DisableButton("ModeButton");
        DisableButton("ContinuousButton");
        DisableButton("DiscreteButton");
        DisableButton("StdVarButton");
        DisableButton("modulereadyup");
    } 

    public void EnableButton(string bName)
    {
        GameObject.Find(bName).GetComponent<Image>().enabled = true;
        GameObject.Find(bName).GetComponent<Button>().enabled = true;
    }

    public void DisableButton(string bName)
    {
        GameObject.Find(bName).GetComponent<Image>().enabled = false;
        GameObject.Find(bName).GetComponent<Button>().enabled = false;
    }

    public void DisableEquations()
    {
        GameObject.Find("std_dev").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("MeanEQ").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("MedianEQ").GetComponent<SpriteRenderer>().enabled = false;
        //GameObject.Find("variance").GetComponent<SpriteRenderer>().enabled = false;
    }
}
