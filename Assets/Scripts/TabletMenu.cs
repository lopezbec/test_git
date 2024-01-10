using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletMenu : MonoBehaviour
{
    public List<GameObject> Menu1 = new List<GameObject>();
    public List<GameObject> Menu2 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchMenuUp()
    {
        for(int i = 0; i < Menu1.Count; i++)
        {
            Menu1[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Menu2.Count; i++)
        {
            Menu2[i].gameObject.SetActive(true);
        }
    }

    public void SwitchMenuDown()
    {
        for (int i = 0; i < Menu1.Count; i++)
        {
            Menu1[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < Menu2.Count; i++)
        {
            Menu2[i].gameObject.SetActive(false);
        }
    }
}
