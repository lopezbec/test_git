using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPointTrigger : MonoBehaviour
{
    public GameObject pointer;
    public GameObject graph;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        graph = GameObject.Find("Graph");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        pointer.SetActive(false);
        graph.GetComponent<GraphManager>().removePoint(index);

    }

    public void TriggerButton(){
        pointer.SetActive(false);
        graph.GetComponent<GraphManager>().removePoint(index);
    }

    public void setIndex(int num)
    {
        index = num;
    }
}
