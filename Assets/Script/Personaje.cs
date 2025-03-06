using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    // private List<GameObject> inventory;

    void Awake()
    {
        // inventory = new List<GameObject>();
         agent = GetComponent<NavMeshAgent>();
    }

    // public void AddInventory(GameObject go){
    //     inventory.Add(go);
    // }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Personaje.PlayAnim()
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point); 
            }
        }
    }
}
