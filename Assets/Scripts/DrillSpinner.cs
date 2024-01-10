using UnityEngine;
using UnityEngine.UI;
public class DrillSpinner : MonoBehaviour
{
    public GameObject infoText;
    public Animation anim;
    public bool playB; //for testing w/o headset

    // Start is called before the first frame update
    void Start()
    {
        //gets the slider for rotatin the drill display
        infoText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(playB == true)
        {
            PlayAnim();
            playB = false;
        }
    }

    public void PlayAnim()
    {
        infoText.gameObject.SetActive(false);
        anim.Play("DrillAnim");
        Invoke("SetText", 1f);
    }

    public void SetText()
    {
        infoText.gameObject.SetActive(true);
    }
}
