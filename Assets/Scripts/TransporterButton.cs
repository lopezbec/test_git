using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransporterButton : MonoBehaviour
{
    //for use on wrist menu. Transports player to upper or lower room depending on which object is attached
    public GameObject upper;
    public GameObject lower;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerUpperButton(){
        if(player.gameObject == null){
            print("Error: Player not set in inspector view");
        }
        else if(upper.gameObject != null){
            player.transform.position = upper.transform.position;
        }
        
    }

    public void TriggerLowerButton(){
        if(player.gameObject == null){
            print("Error: Player not set in inspector view");
        }
        else if(lower.gameObject != null){
            player.transform.position = lower.transform.position;
        }
    }
}
