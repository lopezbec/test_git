using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightArmWorker : MonoBehaviour
{
    public Animation anim;
    NavMeshAgent navMeshAgent;
    public GameObject RightArmPoint;
    public GameObject RightComputerPoint;
    public GameObject RightComputerChair;

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
        if(other.name == "RightArmPoint")
        {
            this.transform.position = RightArmPoint.transform.position;
            this.transform.rotation = RightArmPoint.transform.rotation;
            anim.Play("Working On Device");
            StartCoroutine(ComputerWaiter());
        }

        if(other.name == "RightComputerPoint")
        {
            this.transform.position = RightComputerChair.transform.position;
            this.transform.rotation = RightComputerChair.transform.rotation;
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
        Vector3 targetVector = RightArmPoint.transform.position;
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);
    }

    void SetDestinationComputer()
    {
        Vector3 targetVector = RightComputerPoint.transform.position;
        anim.Play("Walking");
        navMeshAgent.SetDestination(targetVector);

    }
}