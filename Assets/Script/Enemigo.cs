using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Array de puntos de patrulla
    public float waitTime = 2f; // Tiempo de espera en cada punto

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        // Si el enemigo ha llegado a su destino
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                NextWaypoint();
                waitTimer = 0f;
            }
        }
    }

    void NextWaypoint()
    {
        if (waypoints.Length == 0) return;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Ciclo entre waypoints
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
