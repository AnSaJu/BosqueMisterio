using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agente;

    bool focusCollider = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agente.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoverAlPunto(Vector3 punto)
    {
        agente.SetDestination(punto);
    }

    public void FollowTarget(Interactable newTarget) // Seguir al objetivo
    {
     
            agente.stoppingDistance = newTarget.radius * .8f;
            agente.updateRotation = false;
        
     

        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agente.stoppingDistance = 0f;
        agente.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

 
}
