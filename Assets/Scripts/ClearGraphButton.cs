using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearGraphButton : MonoBehaviour
{
    public GameObject graph;
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
        GetComponent<Image>().color = Color.cyan;
        graph.GetComponent<GraphManager>().clearPoints();
        Invoke("MakeAvail", 0.5f);

    }

    public void TriggerButton(){
         GetComponent<Image>().color = Color.cyan;
        graph.GetComponent<GraphManager>().clearPoints();
        Invoke("MakeAvail", 0.5f);
    }

    private void MakeAvail()
    {
        GetComponent<Image>().color = Color.white;
    }
}
