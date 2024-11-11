using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 20f;
    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent; 
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(distanceToTarget > navMeshAgent.stoppingDistance){
            GetComponent<Animator>().SetBool("AttackParam", false);
            GetComponent<Animator>().SetTrigger("MoveParam");
            navMeshAgent.SetDestination(target.position);
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            GetComponent<Animator>().SetBool("AttackParam", true);
        }

        if(distanceToTarget <= chaseRange){
            navMeshAgent.SetDestination(target.position);
        }
    }
}
