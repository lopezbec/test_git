using UnityEngine;
using UnityEngine.UI;

public class ClassroomManager : MonoBehaviour
{
    public GameObject Tutorial;
    Text t;
    Transform station;
    int lessonLocker;

    void Start()
    {
        if (!Tutorial.activeSelf)
            Tutorial.gameObject.SetActive(true);

        Tutorial.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        Tutorial.GetComponent<Canvas>().planeDistance = 4.0f;
    }

    public void Button322Pressed()
    {
        lessonLocker = 0;
        GameObject.Find("readyup").GetComponent<Button>().enabled = true;
        GameObject.Find("readyup").GetComponent<Image>().enabled = true;
    }
    public void Button323Pressed()
    {
        lessonLocker = 1;
        GameObject.Find("readyup").GetComponent<Button>().enabled = true;
        GameObject.Find("readyup").GetComponent<Image>().enabled = true;
    }
    public void Button425Pressed()
    {
        lessonLocker = 2;
        GameObject.Find("readyup").GetComponent<Button>().enabled = true;
        GameObject.Find("readyup").GetComponent<Image>().enabled = true;
    }
    public void Button453Pressed()
    {
        lessonLocker = 3;
        GameObject.Find("readyup").GetComponent<Button>().enabled = true;
        GameObject.Find("readyup").GetComponent<Image>().enabled = true;
    }

    //This function gets called by 
    public void Ready()
    {
        if (lessonLocker == 0)
        {
            LevelMaster.introState++;

            station = GameObject.Find("ToolTable").GetComponent<Transform>();
            GameObject.Find("GrabbyGuy").GetComponent<Transform>().position = new Vector3(station.position.x, 6, station.position.z);
            GameObject.Find("Introduction").GetComponent<UniversalInstructionManager>().enabled = true;
            //GameObject.Find("Selection").GetComponent<UniversalInstructionManager>().enabled = false;
        }
        else if (lessonLocker == 1)
            t.text = "Lesson Not Available Yet";
        else if (lessonLocker == 2)
            t.text = "Lesson Not Available Yet";
        else if (lessonLocker == 3)
            t.text = "Lesson Not Available Yet";
    }
}
