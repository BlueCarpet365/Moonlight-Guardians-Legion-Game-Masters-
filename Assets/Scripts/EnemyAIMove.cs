using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindAndSetTarget();
    }

    void Update()
    {
        if (navMeshAgent.destination == transform.position)
        {
            FindAndSetTarget();
        }
    }

    void FindAndSetTarget()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        if (buildings.Length > 0)
        {
            GameObject randomBuilding = buildings[Random.Range(0, buildings.Length)];
            navMeshAgent.SetDestination(randomBuilding.transform.position);
        }
        else
        {
            Debug.LogWarning("No buildings found with the 'Building' tag!");
        }
    }
}
