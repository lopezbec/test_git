using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightEditorButton : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerStandingButton(){
        player.transform.position -= new Vector3(player.transform.position.x, 0.1f, player.transform.position.z);//new Vector3(19.7399998f,5.65f,7.09000015f);
    }

    public void TriggerSittingButton(){
        player.transform.position += new Vector3(player.transform.position.x, 0.1f, player.transform.position.z);//new Vector3(19.7399998f,5.11176157f,7.09000015f);
    }
}
