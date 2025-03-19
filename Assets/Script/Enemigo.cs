using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomPatrol : MonoBehaviour
{
    public float patrolRadius = 10f; // Radio de patrullaje
    public float waitTime = 2f; // Tiempo de espera entre movimientos

    private NavMeshAgent agent;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomPoint();
    }

    void Update()
    {
        // Si el enemigo llegó a su destino, espera un tiempo antes de moverse de nuevo
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                MoveToRandomPoint();
                waitTimer = 0f;
            }
        }
    }

    void MoveToRandomPoint()
    {
        Vector3 randomPoint = GetRandomPoint(transform.position, patrolRadius);
        agent.SetDestination(randomPoint);
    }

    Vector3 GetRandomPoint(Vector3 center, float radius)
    {
        for (int i = 0; i < 30; i++) // Intenta 30 veces encontrar un punto válido
        {
            Vector3 randomPos = center + Random.insideUnitSphere * radius;
            randomPos.y = center.y; // Mantén la misma altura

            if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return center; // Si no encuentra, se queda en su posición actual
    }
}
