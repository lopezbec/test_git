using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public int State = 0;
    GameObject[] molds;
    GameObject[] spawners;
    void Start()
    {
        State++;
        molds = GameObject.FindGameObjectsWithTag("Mold");
        spawners = GameObject.FindGameObjectsWithTag("MoldSpawn");
        int i;
        for (i = 0; i < molds.Length; i++)
            molds[i].GetComponent<AudioSource>().enabled = true;
        for (i = 0; i < spawners.Length; i++)
            spawners[i].GetComponent<BasicSpawner>().enabled = true;
    }

    void Update() {
        switch (State) {
            case 0:
                break;
            case 1:
                break;

        }
    }


    
}
