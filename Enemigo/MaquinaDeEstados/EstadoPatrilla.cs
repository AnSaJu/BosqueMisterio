using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrilla : MonoBehaviour
{
    public Transform[] wayPoint;

    private MaquinaDeEstado maquinaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private int siguienteWayPoint;

    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        maquinaDeEstado = GetComponent<MaquinaDeEstado>();
    }

    void Update()
    {
        if (controladorNavMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % wayPoint.Length;
            ActualizarWayPointDestino();
        }
    }

    void OnEnable()
    {
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoAgente(wayPoint[siguienteWayPoint].position);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.EstadoAlerta);
        }
    }
}
