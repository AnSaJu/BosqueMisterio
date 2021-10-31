using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimacionE : MonoBehaviour
{
    private NavMeshAgent agente;

    private Animator animator;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
        agente = GetComponent<NavMeshAgent>();
    }


    void Start()
    {

    }

    void Update()
    {
        float velocidadAnimacion = agente.velocity.magnitude / agente.speed;
        animator.SetFloat("CaminarE", velocidadAnimacion);

    }
}
