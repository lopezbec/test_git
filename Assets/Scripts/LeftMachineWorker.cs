using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeftMachineWorker : MonoBehaviour
{
    public Animation anim;
    NavMeshAgent navMeshAgent;
    public GameObject LeftMachinePoint;
    public GameObject LeftBoxPoint;
    public GameObject LeftBoxMachinePoint;
    public GameObject LeftBox;
    public GameObject LeftPointForBox;
    public GameObject heldBoxPosition;
    public GameObject RightHandPoint;
    public GameObject item;
    public GameObject tempMaterial;

    //add random variable needs to be slowed down, moves too fast
    bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        SetDestinationBox();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "LeftMachinePoint")
        {
            this.transform.position = LeftMachinePoint.transform.position;
            if (isHolding)
                PutDown();

            StartCoroutine(insertWaiter());
        }

        if (other.name == "LeftBoxPoint")
        {
            this.transform.position = LeftBoxPoint.transform.position;
            this.transform.rotation = LeftBoxPoint.transform.rotation;
            anim.Play("Rummaging");
            StartCoroutine(MachineWaiter());
        }
    }
    void SetDestinationMachine()
    {
        Vector3 targetVector = LeftMachinePoint.transform.position;
        if (isHolding)
            anim.Play("BoxWalking");
        else
            anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);
    }

    void SetDestinationBox()
    {
        Vector3 targetVector = LeftBoxPoint.transform.position;
        if (isHolding)
            anim.Play("BoxWalking");
        else
            anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);
    }

    IEnumerator MachineWaiter()
    {
        yield return new WaitForSeconds(5);
        PickUp();
        SetDestinationMachine();
    }

    IEnumerator BoxWaiter()
    {
        if (isHolding)
            PutDown();
        yield return new WaitForSeconds(5);
        SetDestinationBox();
    }

    void PickUp()
    {
        LeftBox.transform.position = heldBoxPosition.transform.position;
        LeftBox.transform.rotation = heldBoxPosition.transform.rotation;
        isHolding = true;
    }

    void PutDown()
    {
        this.transform.rotation = LeftBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up");

        LeftBox.transform.position = LeftBoxMachinePoint.transform.position;
        LeftBox.transform.rotation = LeftBoxMachinePoint.transform.rotation;
        isHolding = false;
    }

    void ResetBox()
    {
        LeftBox.transform.position = LeftPointForBox.transform.position;
        LeftBox.transform.rotation = LeftPointForBox.transform.rotation;
    }

    IEnumerator insertWaiter()
    {
        print("entered insert waiter");
        this.transform.rotation = LeftBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = LeftMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f);
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        this.transform.rotation = LeftBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = LeftMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f);
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        this.transform.rotation = LeftBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = LeftMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f);
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        ResetBox();
        SetDestinationBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)//is a box in his hand? if so, keep box position and rotation with his hand
        {
            LeftBox.transform.position = heldBoxPosition.transform.position;
            LeftBox.transform.rotation = heldBoxPosition.transform.rotation;
        }

        tempMaterial.transform.position = RightHandPoint.transform.position;
        tempMaterial.transform.rotation = RightHandPoint.transform.rotation;
    }
}