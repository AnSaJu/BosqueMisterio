using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoAlerta : MonoBehaviour
{


    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agente;
    MaquinaDeEstado maquinaDeEstado;

    void Awake()
    {
        maquinaDeEstado = GetComponent<MaquinaDeEstado>();
    }


    void Start()
    {
        
        target = PlayerManager.instance.player.transform;
        agente = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agente.SetDestination(target.position);

            if (distance <= agente.stoppingDistance)
            {
                //ataque
                FaceTarget();
            }
        }
        else
        {
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.EstadoPatrulla);
        }


    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
