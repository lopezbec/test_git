using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

	Canvas canvas;


    // Use this for initialization
    void Start(){
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            canvas.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            canvas.enabled = false;
    }


}
