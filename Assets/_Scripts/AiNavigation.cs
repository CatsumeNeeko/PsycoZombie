using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavigation : MonoBehaviour
{

    private NavMeshAgent agent;
    private Vector3 targetDestination;
    private float nextMoveTime;
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;
    public float wanderRadius = 10f;
    public float rotationSpeed = 4f;
    public float walkingSpeed = 3f;
    public float detectionRange = 10f;
    [SerializeField] bool isChasingPlayer = false;
    [SerializeField] Transform closestPlayer;
    GameObject[] playersAlive;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if (!isChasingPlayer)
        {
            if (Time.time >= nextMoveTime && !agent.pathPending && agent.remainingDistance < 0.5f)
            {
                RotateBeforeMoving();
                SetRandomDestination();
                float waitTime = Random.Range(minWaitTime, maxWaitTime);
                nextMoveTime = Time.time + waitTime;
                //animator.SetBool("IsWalking", false);

            }
        }
        else
        {
            Transform closestPlayer = GetClosestPlayer();
            if (closestPlayer != null)
            {
                agent.SetDestination(closestPlayer.position);
            }
        }



    }
    #region Wandering
    void SetRandomDestination()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * wanderRadius;
        NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas);
        targetDestination = hit.position;
        agent.SetDestination(targetDestination);
    }
    void RotateBeforeMoving()
    {
        Vector3 targetDirection = targetDestination - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
    #endregion

    void CheckForPlayer()
    {
        closestPlayer = GetClosestPlayer();
        if (closestPlayer != null && Vector3.Distance(transform.position, closestPlayer.position) < detectionRange)
        {
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }
    }
    Transform GetClosestPlayer()
    {
        closestPlayer = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject player in NetworkManagerUI.Instance.players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;
            }
        }

        return closestPlayer;
    }

}
