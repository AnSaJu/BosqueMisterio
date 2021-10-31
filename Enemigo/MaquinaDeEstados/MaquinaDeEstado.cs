using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstado : MonoBehaviour
{
    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicila;

    private MonoBehaviour estadoActual;

    void Start()
    {
        ActivarEstado(EstadoInicila);
    }

  public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if(estadoActual != null)
            estadoActual.enabled = false;

        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }
}
