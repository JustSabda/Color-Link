using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(input.magnitude <= 0)
        {
            //animator.SetBool("Walk", false); 
            return;
        }

        if(Mathf.Abs(input.y)>0.01f)
        {
            Move(input);
        }
        else
        {
            Rotate(input);
        }
    }


    private void Move(Vector2 input)
    {
        //animator.SetBool("Walk", true);
        Vector3 destination = transform.position + transform.right * input.x + transform.forward * input.y;
        navMeshAgent.destination = destination;
    }

    private void Rotate(Vector2 input)
    {
        navMeshAgent.destination = transform.position;
        //animator.SetBool("Walk", false );
        transform.Rotate(0, input.x * navMeshAgent.angularSpeed * Time.deltaTime, 0);
    }
}
