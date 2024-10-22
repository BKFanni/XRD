using UnityEngine;
using UnityEngine.AI;

public class ARPathfinding : MonoBehaviour
{
    public Transform startTransform;  // Transform for the start position
    public Transform destinationTransform;  // Transform for the destination

    private NavMeshAgent agent;

   void Start()
    {if(destinationTransform != null){
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(startTransform.position);  // Move agent to start position

        // Set CanteenDest as the destination
        agent.SetDestination(destinationTransform.position);
        }
    }


    // Set the start position based on the decoded QR code
    public void SetStartPosition(Vector3 position)
    {
        startTransform.position = position;
        agent.Warp(startTransform.position);  // Warp the agent to the start position
    }

    // Set the destination based on the decoded QR code
    public void SetDestination(Transform destination)
    {
        destinationTransform = destination;
        agent.SetDestination(destinationTransform.position);
    }

    void Update()
    {
        if(destinationTransform != null)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log("Reached destination.");
            }
        }
    }
}
