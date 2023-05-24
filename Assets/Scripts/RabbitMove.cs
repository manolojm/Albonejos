using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitMove : MonoBehaviour
{

    Vector3 destino;
    public NavMeshAgent agent;
    public Vector3 min, max;

    private void Start() {

        agent = GetComponent<NavMeshAgent>();
        destino = DestinoAleatorio();
        GetComponent<NavMeshAgent>().SetDestination(destino);
    }

    void Update() {

        //MOVIMIENTO AREA DESINO ALEATORIO
        if (Vector3.Distance(transform.position, destino) < 2f)
        {
            destino = DestinoAleatorio();
            GetComponent<NavMeshAgent>().SetDestination(destino);
        }
    }

    Vector3 DestinoAleatorio() {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
