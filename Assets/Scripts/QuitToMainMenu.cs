using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit_and_Save(){
        //save game information to json file under name
        //quit to main menu
        print("saving...");
        SceneManager.LoadScene("MainMenu");
    }
}
