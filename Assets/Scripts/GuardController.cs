using UnityEngine;
using UnityEngine.AI;
public class GuardController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
