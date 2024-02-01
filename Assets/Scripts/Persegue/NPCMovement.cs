using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool isWalking = false;

    private Animator animator;
    private static readonly int WalkHash = Animator.StringToHash("IsWalking");

    public float walkRadius = 10f;
    public float walkIntervalMin = 5f;
    public float walkIntervalMax = 15f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        StartCoroutine(Wander());
    }

    IEnumerator Wander()
    {
        while (true)
        {
            if (!isWalking)
            {
                Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);

                navMeshAgent.SetDestination(hit.position);
                isWalking = true;

                animator.SetBool(WalkHash, true);

                yield return new WaitForSeconds(Random.Range(walkIntervalMin, walkIntervalMax));

                navMeshAgent.isStopped = true;

                animator.SetBool(WalkHash, false);

                yield return new WaitForSeconds(Random.Range(1f, 3f));

                navMeshAgent.isStopped = false;
                isWalking = false;
            }

            yield return null;
        }
    }
}
