using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LinearConveyor : MonoBehaviour {

	public float distance = 1f;
	public bool instancedMaterial;

	private Rigidbody rb;
	private Collider col;

	public MeshRenderer mr;
    

    public float speed = 0.5f;

    
    public GameObject partDetection;
    public bool stop_belt;
    //private float speedHolder; //holds value of speed temporarily while belt is disabled

    // Use this for initialization
    void Start () {
		RefreshReferences ();
        //stop_belt = partDetection.GetComponent<PartIncoming>().stopConveyer;
		ChangeSpeed (speed);
        
	}

	public void RefreshReferences(){
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		rb.useGravity = false;
		col = gameObject.GetComponent<Collider> ();
		if (col == null) {
			col = gameObject.AddComponent<MeshCollider> ();
		}

		mr = gameObject.GetComponent<MeshRenderer> ();
		if (mr == null)
			mr = gameObject.GetComponentInChildren<MeshRenderer> ();
		if (mr == null)
			Debug.LogError ("Linear Conveyor needs to be attached to the belt Object");

        
	}

	// Update is called once per frame
	void FixedUpdate () {
		// 'Teleport' rigidbody back and Move forward with physics the same amount each frame
		Vector3 mov = transform.forward * Time.deltaTime * speed / distance;
		rb.position =  (rb.position - mov);
		rb.MovePosition (rb.position + mov);


       
        stop_belt = partDetection.GetComponent<PartIncoming>().stopConveyer;
        if (stop_belt)
        {
            stopBelt();
        }
        if(!stop_belt)
        {
            ChangeSpeed(0.5f);
        }
    }

    public void ChangeSpeed (float _speed) {
		// change the speed of the physics and update the shader
		speed = _speed;
        RefreshReferences();
        // Create a new material instance
        
		if (instancedMaterial) {
			Material tempMat = new Material (mr.material);
			tempMat.SetFloat ("_Speed", speed);
			mr.material = tempMat;
		} else {
			mr.material.SetFloat ("_Speed", speed);
		}
        

    }

    public void stopBelt()
    {
        //speedHolder = speed;
        ChangeSpeed(0);
    }

    public void UpdateSpeed(int Speed) {
        speed = (Speed/2.0f) * 0.5f;
    }

}

