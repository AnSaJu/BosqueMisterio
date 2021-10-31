using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector]
    public Transform perseguirObjetivo;

    private NavMeshAgent agente;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    public void ActualizarPuntoDestinoAgente(Vector3 puntoDestino)
    {
       /* agente.destination = puntoDestino;
        agente.isStopped = false;*/
        agente.SetDestination(puntoDestino);
    }

    public void ActualizarPuntoDestinoAgente()
    {
        ActualizarPuntoDestinoAgente(perseguirObjetivo.position);
    }

    public void DetenerAgente()
    {
        /*agente.Stop();*/
        agente.isStopped = true;        
    }

    public bool HemosLlegado()
    {
       return agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending;
    }
}
