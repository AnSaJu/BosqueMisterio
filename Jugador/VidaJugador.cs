using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    
    public Transform posicionfinal;
    public GameObject textoGanaste;
    public PlayerController playerControler;

    public Scene nivel;

    public float tiempo = 1f;

    public bool tutorialCofre = false;

    private float siguientePunto;
    private float tiempoPunto = 1f;


    


    VidaJugadorBarra vidaBarra;

    // Start is called before the first frame update
    void Awake()
    {
        vidaBarra = GetComponent<VidaJugadorBarra>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > siguientePunto)
        {
            siguientePunto = Time.time + tiempoPunto;
            tiempo -= 1f;

        }        

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemigoA") && tiempo<=0)
        {
           
            vidaBarra.TakeDamage(1);
            tiempo = 1f;

            
        }

        if (other.gameObject.CompareTag("Cofre"))
        {
            
            vidaBarra.Aumentar();
            Destroy(other.gameObject);
            tutorialCofre = true;
        }

        if (other.gameObject.CompareTag("Meta"))
        {
            playerControler.enabled = false;           
            textoGanaste.SetActive(true);
            
        }
    }

}
