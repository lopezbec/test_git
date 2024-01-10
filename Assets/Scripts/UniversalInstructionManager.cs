using UnityEngine;
using UnityEngine.UI;

public class UniversalInstructionManager : MonoBehaviour
{
    public GameObject Tutorial;
    public Text TutorialText;

    public TextAsset textInputFile;
    private string[] textLines;

    public AudioClip[] classClips;
    public AudioSource audioSource;

    int state;
    bool press;
    bool first;
    bool finish;
    bool inTower = false;

    public float pressTimeControl;
    float second;


    void Start()
    {
        Tutorial.gameObject.SetActive(true);

        Tutorial.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        Tutorial.GetComponent<Canvas>().planeDistance = 4.0f;

        textLines = textInputFile.text.Split('@');

        state = 0;
        second = 0;
        press = false;
        first = true;
        finish = false;
    }

    void Update()
    {

        if (Time.time >= second)
        {
            press = true;
        }

        if (first && state == 0)
        {
            first = false;
            DoCurrentState(textLines[0], classClips[0]);
        }

        if (OVRInput.GetDown(OVRInput.Button.One) && press)
        {
            if (state < textLines.Length)
            {
                state++;
                Debug.Log("Forward: " + state);

                if(state != textLines.Length)
                {
                    if (checkBlank())
                    {
                        DoCurrentState(textLines[state], classClips[state]);
                    }
                    else
                    {
                        StopLastSound();
                        Tutorial.gameObject.SetActive(false);
                    }
                }
            }

            if (finish == false && state == textLines.Length)
            {
                Debug.Log("Finish: " + state);
                finish = true;
                if (inTower)
                {
                    GameObject.Find("Introduction").GetComponent<DistIntroManager>().resetSelection();
                }
                StopLastSound();
                Tutorial.gameObject.SetActive(false);
            }

            second = pressTimeControl + Time.time;
            press = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && press)
        {
            if (state > 0)
            {
                state--;
                Debug.Log("Backward: " + state);
                
                if (checkBlank())
                {
                    DoCurrentState(textLines[state], classClips[state]);
                }
                else
                {
                    StopLastSound();
                    Tutorial.gameObject.SetActive(false);
                }
            }

            second = pressTimeControl + Time.time;
            press = false;
            finish = false;
        }
    }

    public void DoCurrentState(string text, AudioClip audioClip)
    {
        Tutorial.gameObject.SetActive(true);
        StopLastSound();
        TutorialText.text = text;
        audioSource.PlayOneShot(audioClip);
    }

    public bool checkBlank()
    {
        if (textLines[state][0].Equals('~'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        StopLastSound();
        audioSource.PlayOneShot(audioClip);
    }

    public void StopLastSound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public void setAssets(TextAsset t, AudioClip[] ac)
    {
        textInputFile = t;
        classClips = ac;
        inTower = true;
        Start();
    }
}
