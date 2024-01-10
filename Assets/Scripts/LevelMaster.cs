using UnityEngine;
using UnityEngine.UI;



public class LevelMaster : MonoBehaviour
{
    Dropdown levelSelection, courseSelection;
    Canvas c;
    public static int lessonLocker = 0, introState = 0;

    public int State = 0; //integer to keep track of where within the level the player is

    void Start()
    {
        State++;
    }

    void Update()
    {

        switch (State)
        {
            case 0:
                return;
            case 1: //player is still in classroom
                Classroom();
                return;

            case 2: //player has chosen a level
                //if(introState == 1)
                    return;

            case 3: //level has begun
                Active();
                return;
        }

    }

    public void Classroom() //The player is still within the classroom and has yet to choose a level
    {
        GameObject.Find("Selection").GetComponent<ClassroomManager>().enabled = true;
    }

    public void Active() //The player has begun their task
    {
        GameObject.Find("Level").GetComponent<LessonManager>().enabled = true;
    }

}

