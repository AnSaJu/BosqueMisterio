using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public LayerMask mascaraMovimiento;

    public Interactable focus;

    public bool enJuego = true;

    

    private bool focusCollider = false;

    Camera cam;
    PlayerMotor motor;

  
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enJuego)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, mascaraMovimiento))
            {
                motor.MoverAlPunto(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1) && enJuego)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {

                

                    SetFocus(interactable);
                    

                }
            }
        }
    }


    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDeFocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
            
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDeFocused();

        focus = null;
        motor.StopFollowingTarget();

        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            focusCollider = true;
           

        }
        else
        {
            focusCollider = false;
        }
    }

   


}
