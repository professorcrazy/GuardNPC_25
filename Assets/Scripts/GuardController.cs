using UnityEngine;
using UnityEngine.AI;
public class GuardController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    private Vector3 target;
    private GameObject player;
    public float viewDistance = 5f;
    [SerializeField] private float viewAngle = 55f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length >= 2)
        {
            transform.position = waypoints[0].position;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // FixedUpdate is called once per physics update (standard 50 times per second)
    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 toPlayerVector = player.transform.position - transform.position;
        Vector3 rightSide = Quaternion.AngleAxis(viewAngle, Vector3.up) * transform.forward;
        Vector3 leftSide = Quaternion.AngleAxis(-viewAngle, Vector3.up) * transform.forward;
        Debug.DrawLine(transform.position, transform.position + (rightSide * viewDistance) , Color.red);
        Debug.DrawLine(transform.position, transform.position + (leftSide * viewDistance) , Color.red);
        if (Physics.Raycast(transform.position, 
            toPlayerVector,
            out hit, viewDistance))
        {
            if (hit.collider.tag == "Player")
            {
                if (Vector3.Dot(toPlayerVector.normalized, transform.forward) >= Mathf.Cos(viewAngle))
                {
//                    Debug.DrawLine(transform.position, player.transform.position, Color.red);
                    Debug.Log("I see you");
                }
            }
        }

        if (agent.remainingDistance <= 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
