using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clique : MonoBehaviour
{
    public Vector3 Destino;
    private NavMeshAgent Agente;
    // Start is called before the first frame update
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousepoint = Input.mousePosition;
            Ray castpoint = Camera.main.ScreenPointToRay(mousepoint);
            RaycastHit hit;
            if (Physics.Raycast(castpoint, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.point);
                Destino = hit.point;
            }
        }
        Agente.SetDestination(Destino);
    }
}
