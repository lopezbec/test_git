using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeftArmWorker : MonoBehaviour
{
    public Animation anim;
    NavMeshAgent navMeshAgent;
    public GameObject LeftArmPoint;
    public GameObject LeftComputerPoint;
    public GameObject LeftComputerChair;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        SetDestinationArm();
        //anim.Play("Working On Device");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "LeftArmPoint")
        {
            this.transform.position = LeftArmPoint.transform.position;
            this.transform.rotation = LeftArmPoint.transform.rotation;
            anim.Play("Working On Device");
            StartCoroutine(ComputerWaiter());
        }

        if (other.name == "LeftComputerPoint")
        {
            this.transform.position = LeftComputerChair.transform.position;
            this.transform.rotation = LeftComputerChair.transform.rotation;
            anim.Play("SitToType");
            anim.Play("Typing");
            StartCoroutine(ArmWaiter());
            
        }
    }

    IEnumerator ComputerWaiter()
    {
        yield return new WaitForSeconds(5);
        SetDestinationComputer();
    }

    IEnumerator ArmWaiter()
    {
        yield return new WaitForSeconds(5);
        SetDestinationArm();
    }

    void SetDestinationArm()
    {
        Vector3 targetVector = LeftArmPoint.transform.position;
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);
    }

    void SetDestinationComputer()
    {
        Vector3 targetVector = LeftComputerPoint.transform.position;
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);

    }
}