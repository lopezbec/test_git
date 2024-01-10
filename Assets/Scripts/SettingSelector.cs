using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSelector : MonoBehaviour
{
    public GameObject setting; //settings menu
    public GameObject notification; //notification menu
    //private bool notificationCheck = true; //notification is initialized at true, meaning active
    private bool check = false; //check if setting is active (set to not active)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerButton(){
        if (true)
        {
            if (check == false)
            {
                setting.SetActive(true);
                check = true;
            }
            else
            {
                setting.SetActive(false);
                check = false;
            }
            if(notification != false){
                //notification.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        if (true)
        {
            if (check == false)
            {
                setting.SetActive(true);
                check = true;
            }
            else
            {
                setting.SetActive(false);
                check = false;
            }
            if(notification != false){
                //notification.SetActive(false);
            }
        }
    }
}
