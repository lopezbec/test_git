using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoButton : MonoBehaviour
{
    public GameObject graph;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //GetComponent<Image>().color = Color.cyan;
        graph.GetComponent<GraphManager>().undoLastPoint();
        Invoke("MakeAvail", 0.5f);

    }

    public void TriggerButton(){
        graph.GetComponent<GraphManager>().undoLastPoint();
        Invoke("MakeAvail", 0.5f);
    }

    private void MakeAvail()
    {
        //GetComponent<Image>().color = Color.white;
    }
}
