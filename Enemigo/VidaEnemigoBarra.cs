using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigoBarra : MonoBehaviour
{
    public GameObject muerteEnemigo;

    public float inicioDeVida = 10f;
    public Slider slider;
    public Image FillImage;
    public Color FullColor = Color.green;
    public Color ZecoColor = Color.red;
    public GameObject explosion;

    public GameObject enemigoAni;

    public AudioSource sonidoEnemigo;
   

    private AudioSource explosionAudio;
    private ParticleSystem explosionParticulas;
    private float currenHealth;
    private bool muerto;

    AnimacionPersonaje aniPer;
    

    void Awake()
    {

        aniPer = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimacionPersonaje>();
        sonidoEnemigo = GetComponent<AudioSource>();

    }
  
    private void OnEnable()
    {
        currenHealth = inicioDeVida;
        muerto = false;
        SetHealthUI();
    }

 


    public void TakeDamage(float amount)
    {
        currenHealth -= amount;
        sonidoEnemigo.Play();
        SetHealthUI();

        if (currenHealth <= 0 && !muerto)
        {
            
            OnDeath();

        }
    }


    void SetHealthUI()
    {
        slider.value = currenHealth;
        FillImage.color = Color.Lerp(ZecoColor, FullColor, currenHealth / inicioDeVida);
    }

    void OnDeath()
    {
        Vector3 posicionMuerte = transform.position - new Vector3(0f, 1f, 1f);
        Instantiate(muerteEnemigo, posicionMuerte, transform.rotation);

        Invoke("DesactivarAnimacionJugador", 0.3f);        
        muerto = true;
        enemigoAni.SetActive(false);
        
    }

    void DesactivarAnimacionJugador()
    {
        aniPer.DetenerAnimacion();
    }

}
