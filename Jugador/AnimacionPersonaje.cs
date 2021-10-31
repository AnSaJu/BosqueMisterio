using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimacionPersonaje : MonoBehaviour
{
    public bool enJuegoAni = true;

    public float restaTiempo;
    public float detenerAnimacion;
    public float tiempoAnimacion;

    public bool tutorialAtacar = false;

    Camera cam;
    bool ataqueJu = false;
    public LayerMask mascaraEnemigo;
   
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
        cam = Camera.main;
        
    }

    void Update()
    {
    

        if (Input.GetMouseButtonDown(0) && enJuegoAni)
        {
            DetenerAnimacion();
        }


            float velocidadAnimacion = agente.velocity.magnitude / agente.speed;
        animator.SetFloat("Caminar", velocidadAnimacion);

        if (Input.GetMouseButtonDown(1) && !ataqueJu)
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mascaraEnemigo) && !ataqueJu)
            {
                tutorialAtacar = true;
                ataqueJu = true;
                


            }
        }

    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemigoA") && ataqueJu)
        {
            animator.SetBool("Atacar", true);
            ataqueJu = false;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemigoA"))
        {
            animator.SetBool("Atacar", false);
        }
    }

    public void DetenerAnimacion()
    {
        animator.SetBool("Atacar", false);
        
    }

    public void MuerteAni()
    {
        animator.SetBool("Muerte", true);
    }
}
