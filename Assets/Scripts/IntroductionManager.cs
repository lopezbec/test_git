using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    int state = 1, textState = 0, moduleSelection;

    
    public Image bg;
    public Text tutorialText;
    public List<AudioClip> meanSounds, medianSounds, modeSounds, stdvarSounds;
    List<AudioClip> sounds; //set this list equal to the correct list on ready pressed
    bool meanFlag = false;

    string s, introString;
    string[] sarr;
    List<introTextSoundSequence> sequence;

    Transform station;
    GameObject modReady, teleport, eq, currInstructions, controlInstructions;
    IntroductionManager introduction;
    Dropdown moduleDrop;
    SpriteRenderer sr;
    bool backPressed = false;
    private float timeElasped = 0;

    public static string[] moduleStartedText = { "mean started", "median started", "mode started", "std/variance started" , "cont dist started", "discrete dist started" };

    private class introTextSoundSequence
    {
        internal AudioManager.Sound clip;
        internal string displaytext;
        internal bool srEnable, modButton, modImage, telButton, telImage;

        //public introTextSoundSequence(AudioManager.Sound sound)
    }

    // Start is called before the first frame update
    void Start()
    {
        //tutorial.setactive(true);
        //tutorial.getcomponent<canvas>().enabled = true;
        //file.writealllines

        tutorialText = GameObject.Find("ModuleInstructions").GetComponent<Text>();
        controlInstructions = GameObject.Find("ControlInstructions");
        //tutorial.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        tutorialText.GetComponent<Canvas>().planeDistance = 3.0f;

        modReady = GameObject.Find("modulereadyup");
        teleport = GameObject.Find("teleport button");

        modReady.GetComponent<Button>().enabled = false;
        modReady.GetComponent<Image>().enabled = false;

        teleport.GetComponent<Button>().enabled = false;
        teleport.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.Two))
        //backPressed = true;
        //Debug.Log("State: " + textState + ", Text: " + sarr[textState]);    

        timeElasped += Time.deltaTime;


        if (((state == 2 || state == 3 || state == 4 || state == 5) && OVRInput.GetDown(OVRInput.Button.One)) || state == 1)
        {
            if (backPressed)
            {
                backPressed = false;
                state--;
                textState--;
            }

            tutorialText.text = sequence[textState].displaytext;
            AudioManager.PlaySound(sequence[textState].clip);
            state++;
            textState++;
        }
        else if (state == 6 && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (backPressed)
            {
                backPressed = false;
                state--;
                textState--;
            }

            tutorialText.gameObject.SetActive(true);

            tutorialText.text = sequence[textState].displaytext;
            AudioManager.PlaySound(sequence[textState].clip);
            state++;
            textState++;
        }
        else if (state == 7 && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (backPressed)
            {
                backPressed = false;
                state--;
                textState--;
            }

            tutorialText.text = sequence[textState].displaytext;
            AudioManager.PlaySound(sequence[textState].clip);
            state++;
            textState++;
        }
        else if (state == 8 && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (backPressed)
            {
                backPressed = false;
                state--;
            }

            tutorialText.gameObject.SetActive(false);
            sr.enabled = true;
            if (meanFlag)
                eq.GetComponentInChildren<MeshRenderer>().enabled = true;

            state++;
        }
        else if (state == 9 && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (backPressed)
            {
                backPressed = false;
                state--;
                textState--;
            }
            
            sr.enabled = false;
            if (meanFlag)
                eq.GetComponentInChildren<MeshRenderer>().enabled = false;

            tutorialText.gameObject.SetActive(true);

            tutorialText.text = sequence[textState].displaytext;
            AudioManager.PlaySound(sequence[textState].clip);
            state++;
            textState++;
        }
        else if (state == 10 && OVRInput.GetDown(OVRInput.Button.One))
        {
            tutorialText.text = sequence[textState].displaytext;
            AudioManager.PlaySound(sequence[textState].clip);
            state++;
            textState++;
        }
        else if (state == 11 && OVRInput.GetDown(OVRInput.Button.One))
        {
            GameObject.Find("Level").GetComponent<LessonManager>().enabled = false;

            tutorialText.GetComponent<Canvas>().enabled = false;

            modReady.GetComponent<Button>().enabled = true;
            modReady.GetComponent<Image>().enabled = true;

            teleport.GetComponent<Button>().enabled = true;
            teleport.GetComponent<Image>().enabled = true;

            File.WriteAllText("/sdcard/oculus/VRFiles/random.txt", "module completed in " + timeElasped + "seconds");

            meanFlag = false;
            introduction.enabled = false;
        }
    }

    public void MeanButtonPressed()
    {
        moduleSelection = 0;
    }
    public void MedianButtonPressed()
    {
        moduleSelection = 1;
    }
    public void ModeButtonPressed()
    {
        moduleSelection = 2;
    }
    public void StdVarButtonPressed()
    {
        moduleSelection = 3;
    }
    public void DistributionsButtonPressed()
    {
        moduleSelection = 4;
    }

    public void ModuleReadyPressed()
    {
        File.WriteAllText("/sdcard/oculus/VRFiles/random.txt", moduleStartedText[moduleSelection]);
        switch (moduleSelection)
        {
            case 0: //mean
                sounds = meanSounds;   
                eq = GameObject.Find("MeanEQ");
                sr = eq.GetComponent<SpriteRenderer>();

                //AudioClip[] a = GameObject.Find("").GetComponents<AudioClip>();

                meanFlag = true;

                GameObject.Find("Introduction").GetComponent<IntroductionManager>().enabled = true;
                

                break;
            case 1: //median
                sounds = medianSounds;
                sr = GameObject.Find("MedianEQ").GetComponent<SpriteRenderer>();

                GameObject.Find("modulereadyup").GetComponent<Button>().enabled = false;
                GameObject.Find("modulereadyup").GetComponent<Image>().enabled = false;

                GameObject.Find("Introduction").GetComponent<IntroductionManager>().enabled = true;

                break;
            case 2: //mode
                sounds = modeSounds;
                
                sr = GameObject.Find("ModeEQ").GetComponent<SpriteRenderer>();

                GameObject.Find("modulereadyup").GetComponent<Button>().enabled = false;
                GameObject.Find("modulereadyup").GetComponent<Image>().enabled = false;

                GameObject.Find("Introduction").GetComponent<IntroductionManager>().enabled = true;

                break;
            case 3: //std dev and variance, variability
                sounds = stdvarSounds;
               
                sr = GameObject.Find("ModeEQ").GetComponent<SpriteRenderer>();

                GameObject.Find("modulereadyup").GetComponent<Button>().enabled = false;
                GameObject.Find("modulereadyup").GetComponent<Image>().enabled = false;

                GameObject.Find("Introduction").GetComponent<IntroductionManager>().enabled = true;
                break;
            case 4: //distributions
                //start distribution intro manager
                //GameObject.Find("")
                break;
        }
    }
}