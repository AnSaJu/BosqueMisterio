using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{

    public AudioSource sonidoMeta;
    public int scenaSiguiente = 2;
    // Start is called before the first frame update
    void Start()
    {
        sonidoMeta = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            sonidoMeta.Play();
            Invoke("CargarScena", 3f);
        }
    }

    void CargarScena()
    {
        SceneManager.LoadScene(scenaSiguiente);
    }
}
