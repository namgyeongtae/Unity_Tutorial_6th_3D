using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour, ITriggerEvent
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wanderRadius = 15f;
    private float minWaitTime = 1f, maxWaitTime = 5f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            SetRandomDestination();
            anim.SetBool("IsWalk", true);

            // 길 찾기 종료 && 남아있는 거리 <= 정지 거리
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool("IsWalk", false);
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRadius;

        randomDir += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    public void InteractionEnter()
    {
        AnimalArea.failAction?.Invoke();
    }

    public void InteractionExit()
    {
        
    }
}
