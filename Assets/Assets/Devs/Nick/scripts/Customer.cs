using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
   NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CustomerSpot"))
        {
            agent.SetDestination(other.gameObject.transform.position);
        }
    }
}
