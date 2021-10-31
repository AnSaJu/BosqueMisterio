using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    private float siguientePunto;
    private float tiempoPunto = 1f;
    public float tiempo = 1f;

   

    Camera cam;
    bool ataqueE = false;
    

    public LayerMask mascaraEnemigo;
    public Transform player;
    public float radius = 3f;

    private VidaEnemigoBarra vidaEnemigoBarra;

   
    void Start()
    {
        
        cam = Camera.main;
        vidaEnemigoBarra = GetComponent<VidaEnemigoBarra>();
       

    }

    void Update()
    {
        if (Time.time > siguientePunto)
        {
            siguientePunto = Time.time + tiempoPunto;
            tiempo -= 1f;
            
        }


        if (Input.GetMouseButtonDown(0))
        {
            ataqueE = false;
        }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100, mascaraEnemigo))
                    {
                        
                        ataqueE = true;
                    }            
            }
    }

    void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.CompareTag("PlayerA") && tiempo <= 0 && ataqueE )
        {

            tiempo = 2f;

            vidaEnemigoBarra.TakeDamage(1);
        }
    }
    
}
