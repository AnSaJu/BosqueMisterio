using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMenu : MonoBehaviour
{
    public Light luz;
    public Color colorA, colorB;
    private float velocidad = 1f;

    public float tiempo = 1f;
    public float tiempoPunto = 0.5f;
    private float siguientePunto;
    private bool cambioColor = false;
    

    void Awake()
    {
        luz = GetComponent<Light>();
    }

    // Update is called once per frame
 
    void Update()
    {
        luz.color = Color.Lerp(colorA, colorB, velocidad / tiempo);

        if (tiempo <= 4f && !cambioColor)
        {
            tiempo += 1f * Time.deltaTime;
            if(tiempo >= 4f)
            {
                cambioColor = true;
            }
        }
        else
        {
            if (tiempo >= 1f && cambioColor)
            {
                tiempo -= 1f * Time.deltaTime;
                if (tiempo <= 1f)
                {
                    cambioColor = false;
                }
            }

        }


    }
}

/*
if (Time.time > siguientePunto)
        {
            siguientePunto = Time.time + tiempoPunto;
            tiempo += 0.1f;
            Debug.Log(tiempo);

        }

        if(tiempo >= 2f)
        {
            tiempo = -tiempo;
        }
        */