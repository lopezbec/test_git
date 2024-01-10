using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    Animator animator;
    public InputAction grip;

    // Start is called before the first frame update
    void Start()
    {
        grip.Enable();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grip.IsPressed()){
            //animator.SetBool("point", "True");
            //animator.SetBool("normal", "False");
        }
        else{
            //animator.SetBool("normal", "True");
            //animator.SetBool("point", "False");
        }
    }
}
