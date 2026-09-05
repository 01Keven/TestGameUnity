using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] GameObject playerObject;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }    
    }
}
