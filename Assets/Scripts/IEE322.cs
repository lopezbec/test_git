using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEE322 : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvas;
    public GameObject button322;
    public GameObject button323;
    public GameObject buttonview;
    public GameObject buttonfactory;
    public static bool iee322 = false;
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
        iee322 = true;
        canvas.SetActive(false);
        button322.SetActive(false);
        button323.SetActive(false);
        buttonview.SetActive(true);
        buttonfactory.SetActive(true);
        //Player.transform.localPosition = new Vector3(19.034f, 5.672f, 7.187f);
    }
}
