using UnityEngine;

public class Chest : MonoBehaviour
{
    public float detectionRadius = 2f; // Distancia para interactuar con el cofre
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Si el jugador está cerca y presiona "E"
        if (distance <= detectionRadius && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Has abierto un cofre.");
        }
    }

    // Dibujar el radio de detección en la escena para depuración
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
