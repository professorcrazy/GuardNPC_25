using UnityEngine;
using UnityEngine.AI;
public class GuardController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length >= 2)
        {
            transform.position = waypoints[0].position;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    // FixedUpdate is called once per physics update (standard 50 times per second)
    void FixedUpdate()
    {
        if (agent.remainingDistance <= 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
