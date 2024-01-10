using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour {

 
    

    private Canvas canvas;
    private GameObject keyboard;
    private Text notes;

    public GameObject NoteBookObject;

    private string header = "Notes: ";
    List<string> pages = new List<string>(); //list of strings, each string corresponds to a page
    int pagenumber = 0;

    // Use this for initialization
    void Start() {
        canvas = gameObject.GetComponent<Canvas>(); //the entire canvas UI element can be toggled with this
        keyboard = this.transform.Find("KeyBoard").gameObject;//child object is named KeyBoard
        notes = this.transform.Find("NotesText").gameObject.GetComponent<Text>(); //gets the current text on display on the notebook
        pages.Add(notes.text); //adds initialized notes text as the first page
    }

    void Update()
    {

     

        //turns the page on the notebook left
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || OVRInput.GetDown(OVRInput.Button.Three)) && canvas.enabled){ 
            pagenumber -= 1;
            if (pagenumber < 0)
                pagenumber = 0;
            notes.text = pages[pagenumber];
        }

        //turns the page to the right on the notebook
        if ((Input.GetKeyDown(KeyCode.RightArrow) || OVRInput.GetDown(OVRInput.Button.Four)) && canvas.enabled){ 
            pagenumber += 1;
            if (pagenumber > pages.Count - 1)
                pages.Add(header + pagenumber.ToString() + "\n");
            notes.text = pages[pagenumber];
        }


    }
   


    public void UpdateString(string str) {
        string updatedtext;
        if (str == "[space]"){
            updatedtext = pages[pagenumber] + " ";
            pages.RemoveAt(pagenumber);
            pages.Insert(pagenumber, updatedtext);
        }
        else if (str == "[backspace]"){
            pages[pagenumber] = pages[pagenumber].Substring(0, notes.text.Length - 1); //deletes the last character by reassigning to the substring of itself -1
        }
        else if (str == "[enter]") {
            updatedtext = pages[pagenumber] + "\n";
            pages.RemoveAt(pagenumber);
            pages.Insert(pagenumber, updatedtext);
        }
        else {
            updatedtext = pages[pagenumber] + str;
            pages.RemoveAt(pagenumber);
            pages.Insert(pagenumber, updatedtext);
        }

        notes.text = pages[pagenumber];

    }



}

