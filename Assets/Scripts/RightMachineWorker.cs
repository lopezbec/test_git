using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightMachineWorker : MonoBehaviour
{
    public Animation anim;
    NavMeshAgent navMeshAgent;
    public GameObject RightMachinePoint; //collider in front of machine
    public GameObject RightBoxPoint; //collider in front of box
    public GameObject RightBoxMachinePoint;//collider for where he puts down the box
    public GameObject RightBox; // box the worker uses
    public GameObject RightPointForBox; // point where he grabs the box out of
    public GameObject heldBoxPosition; // 
    public GameObject RightHandPoint; // hand of the worker
    public GameObject item; // 
    public GameObject tempMaterial;

    bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        SetDestinationBox();
    }
    public void OnTriggerEnter(Collider other) //when at the main box, the worker starts rummaging and pulls out a smaller box
    {
        if (other.name == "RightMachinePoint") //determines if the worker has arrived at the amachine
        {
      //      this.transform.position = RightMachinePoint.transform.position; // this snapping into place might be what makes animation awkward

            if (isHolding) 
                PutDown();

            StartCoroutine(insertWaiter());
        }

        if (other.name == "RightBoxPoint")
        {
           // this.transform.position = RightBoxPoint.transform.position;
           // this.transform.rotation = RightBoxPoint.transform.rotation;
            anim.Play("Rummaging");
            StartCoroutine(MachineWaiter());
        }
    }
    void SetDestinationMachine() // makes the worker go to the machine
    {
        Vector3 targetVector = RightMachinePoint.transform.position;
        if (isHolding)
            anim.Play("BoxWalking");
        else
            anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);
    }

    void SetDestinationBox() //makes the worker go to the box
    {
        Vector3 targetVector = RightBoxPoint.transform.position;
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

        yield return new WaitForSeconds(10);
        ResetBox();
        SetDestinationBox();
    }

    void PickUp()//pick up box
    {
        RightBox.transform.position = heldBoxPosition.transform.position;
        RightBox.transform.rotation = heldBoxPosition.transform.rotation;
        isHolding = true;
    }

    void PutDown() //put down box
    {
        this.transform.rotation = RightBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up");

        RightBox.transform.position = RightBoxMachinePoint.transform.position;
        RightBox.transform.rotation = RightBoxMachinePoint.transform.rotation;
        isHolding = false;
    }

    IEnumerator insertWaiter() // picking up the material and putting it in the machine, then returns the box and starts walking back to main box
    {
        print("entered insert waiter");
        this.transform.rotation = RightBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = RightMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f);
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        this.transform.rotation = RightBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = RightMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f);
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        this.transform.rotation = RightBoxMachinePoint.transform.rotation;
        anim.Play("Picking Up Material");
        yield return new WaitForSeconds(1);

        this.transform.rotation = RightMachinePoint.transform.rotation;
        tempMaterial = Instantiate(item, RightHandPoint.transform.position, RightHandPoint.transform.rotation) as GameObject;
        tempMaterial.transform.localScale = new Vector3(0.128f, -0.184f, -0.044f); 
        anim.Play("Dropping In");
        yield return new WaitForSeconds(1);

        Destroy(tempMaterial);
        ResetBox();
        SetDestinationBox();
    }

    void ResetBox()//send box back to starting position
    {
        RightBox.transform.position = RightPointForBox.transform.position;
        RightBox.transform.rotation = RightPointForBox.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)//is a box in his hand? if so, keep box position and rotation with his hand
        {
            RightBox.transform.position = heldBoxPosition.transform.position;
            RightBox.transform.rotation = heldBoxPosition.transform.rotation;
        }

        tempMaterial.transform.position = RightHandPoint.transform.position;
        tempMaterial.transform.rotation = RightHandPoint.transform.rotation;
    }
}