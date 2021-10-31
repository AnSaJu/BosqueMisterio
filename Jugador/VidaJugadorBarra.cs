using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJugadorBarra : MonoBehaviour
{
    public Transform posicionfinal;

    public float inicioDeVida = 10f;
    public Slider slider;
    public Image FillImage;
    public Color FullColor = Color.green;
    public Color ZecoColor = Color.red;
    public GameObject explosion;

    public GameObject textoFinJuego;
    public AudioSource sonidoAtaque;
    public AudioClip clipVida;
    public AudioClip clipAtaque;


    private AudioSource explosionAudio;
    private ParticleSystem explosionParticulas;
    private float currenHealth;
    private bool muerto;

    private PlayerController enJuego;
    private AnimacionPersonaje enJuegoAni;

    void Awake()
    {
        enJuego = GetComponent<PlayerController>();
        enJuegoAni = GetComponent<AnimacionPersonaje>();
        sonidoAtaque = GetComponent<AudioSource>();
        
    }

    private void OnEnable()
    {
        currenHealth = inicioDeVida;
        muerto = false;
        SetHealthUI();
    }

    public void Aumentar()
    {
        sonidoAtaque.clip = clipVida;
        sonidoAtaque.Play();
        currenHealth += 5;
        SetHealthUI();
        if(currenHealth > inicioDeVida)
        {
            currenHealth = inicioDeVida;
        }
        Invoke("CargarSonido", 2f);
    }

    public void TakeDamage(float amount)
    {
        currenHealth -= amount;

        SetHealthUI();

        sonidoAtaque.Play();

        if (currenHealth <= 1 && !muerto)
        {
            enJuego.enJuego = false;
            enJuegoAni.enJuegoAni = false;
            enJuegoAni.MuerteAni();
            // OnDeath();
            Invoke("OnDeath", 3f);            
            
        }
    }


    void SetHealthUI()
    {
        slider.value = currenHealth;
        FillImage.color = Color.Lerp(ZecoColor, FullColor, currenHealth / inicioDeVida);
    }

    void OnDeath()
    {
        
        transform.position = posicionfinal.position;
        transform.rotation = posicionfinal.rotation;
        textoFinJuego.SetActive(true);
        muerto = true;
        gameObject.SetActive(false);
        Invoke("CargarScena",3f);
    }

   

    void CargarScena()
    {
        SceneManager.LoadScene(0);
    }

    void CargarSonido()
    {
        sonidoAtaque.clip = clipAtaque;
    }
}
