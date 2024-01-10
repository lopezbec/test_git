using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject Menu;


    // Start is called before the first frame update
    void Start()
    {
        //test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerButton(){
            Menu.SetActive(!Menu.active);
    }
}
