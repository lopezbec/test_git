using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject button322;
    public GameObject button323;
    public GameObject buttonview;
    public GameObject buttonfactory;
    public GameObject walking;
    public GameObject teleporting;
    public GameObject back;
    public GameObject settings;

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
        if (IEE323.iee323 == true || IEE322.iee322 == true)
        {
            buttonview.SetActive(true);
            buttonfactory.SetActive(true);
            walking.SetActive(false);
            teleporting.SetActive(false);
            back.SetActive(false);
            settings.SetActive(true);
        }
        else
        {
            button322.SetActive(true);
            button323.SetActive(true);
            walking.SetActive(false);
            teleporting.SetActive(false);
            back.SetActive(false);
            settings.SetActive(true);
        }
    }
}
