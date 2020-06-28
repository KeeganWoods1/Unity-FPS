using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;

    [SerializeField] float attackAnimationRange = 3f;
    [SerializeField] float turnSpeed = 5f;
    float distanceToTarget = Mathf.Infinity;

    NavMeshAgent navMeshAgent;
    Animator animator;

    void Start()
    {
        target = FindObjectOfType<Camera>().transform;
        animator = gameObject.GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(target.position);
        UpdateEnemyAnimation();
        
    }

    private void UpdateEnemyAnimation()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= attackAnimationRange)
        {
            FaceTarget();
            animator.SetBool("isWalking", false);
        }

        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
