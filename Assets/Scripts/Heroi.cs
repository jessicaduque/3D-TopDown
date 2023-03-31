using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Heroi : MonoBehaviour
{
    private NavMeshAgent Agente;
    public Vector3 Destino;

    // Start is called before the first frame update
    void Start()
    {
        Destino = new Vector3(0, 0, 0);
        Agente = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousepoint = Input.mousePosition;
            Ray pontoDeSaida = Camera.main.ScreenPointToRay(mousepoint);
            RaycastHit localTocou;
            if(Physics.Raycast(pontoDeSaida, out localTocou, Mathf.Infinity)){
                Destino = localTocou.point;
            }
        }

        Agente.SetDestination(Destino);
    }
}
