using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image imagenMover;
    public Image imagenAtacar;
    public Image imagenCamara;
    public Image imagenCobre;
    public Image imagenMeta;

    private AnimacionPersonaje tutorialAtacar;
    private VidaJugador tutorialCofre;

    bool atacarIm = true;
    bool moverIm = true;
    bool camaraIm = true;
    bool vidaIm = false;

    // Start is called before the first frame update
    void Awake()
    {
        tutorialCofre = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
        tutorialAtacar = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimacionPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && imagenMover.enabled == true && atacarIm == true)
        {
            imagenMover.enabled = false;
            imagenAtacar.enabled = true;
            atacarIm = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(1) && imagenAtacar.enabled == true && tutorialAtacar.tutorialAtacar && moverIm == true)
            {
                imagenAtacar.enabled = false;
                imagenCamara.enabled = true;
                moverIm = false;
            }
            else
            {
                if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && imagenCamara.enabled == true && camaraIm == true)
                {
                    imagenCamara.enabled = false;
                    imagenCobre.enabled = true;
                    tutorialCofre.tutorialCofre = false;
                    camaraIm = false;
                    vidaIm = true;
                }
                else
                {
                    if (tutorialCofre.tutorialCofre && imagenCobre.enabled == true && vidaIm == true)
                    {
                        imagenCobre.enabled = false;
                        imagenMeta.enabled = true;
                        vidaIm = false;
                        gameObject.SetActive(false);
                    }
                }

               
            }

            
        } 

    }

}
