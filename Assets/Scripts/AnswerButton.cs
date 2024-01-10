using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public GameObject sampleSource;
    public bool showAnswer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(showAnswer == true) //used for inspector testing
        {
            sampleSource.GetComponent<Sample>().getAnswer();
            Invoke("MakeAvail", 0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Image>().color = Color.cyan;
        sampleSource.GetComponent<Sample>().getAnswer();
        Invoke("MakeAvail", 0.5f);
    }

    public void TriggerButton(){
        GetComponent<Image>().color = Color.cyan;
        sampleSource.GetComponent<Sample>().getAnswer();
        Invoke("MakeAvail", 0.5f);
    }

    private void MakeAvail()
    {
        GetComponent<Image>().color = Color.white;
        showAnswer = false;
    }
}
