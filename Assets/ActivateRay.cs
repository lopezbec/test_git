using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateRay : MonoBehaviour
{
    // Start is called before the first frame update
    public InputAction r3;
    public bool active;
    public bool locked = false;
    public GameObject hands;
    public GameObject rays;

    void Start()
    {
        r3.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (r3.IsPressed() && !locked)
        {
            locked = true;
            active = !active;
            updateRayCast();
        }
    }

    public void updateRayCast()
    {
        if (active)
        {
            rays.SetActive(true);
            hands.SetActive(false);
        }
        if (!active)
        {
            rays.SetActive(false);
            hands.SetActive(true);
        }
        Invoke("unLock", 0.2f);
    }

    public void unLock()
    {
        locked = false;
    }
}
