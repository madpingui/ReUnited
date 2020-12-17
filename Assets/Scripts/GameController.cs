using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject TapPanel;
    public GameObject InGamePanel;
    public GameObject EndPanel;
    public Animator MenuController, TapController;
    private float tiempo = 90;
    public Text tiempoText;
    private bool lose;
    private AudioSource audioS;
    public AudioClip inicio, fondo, dead;

    public Text parceritosSalvadosText;
    public Text asteroidesReunidosText;
    public Text planetasReunidosText;
    public Text puntajeTotal;

    [HideInInspector]
    public bool once = false;

    public static GameController Instance { set; get; }

    // Use this for initialization
    void Start () 
    {
        lose = false;
        audioS = GetComponent<AudioSource>();
        Instance = this;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(once == true)
        {
            tiempo -= Time.deltaTime;
            tiempoText.text = ""+ tiempo.ToString("0");
        }

        if(tiempo <= 0 && lose == false)
        {
            lose = true;
            EndPanel.SetActive(true);
            stickyBall.Instance.Die();
            Time.timeScale = 0;
        }
    }

    public void TapGC()
    {
        once = true;
        TapController.SetTrigger("Hide");
        InGamePanel.SetActive(true);
        audioS.volume = 0.8f;
        audioS.clip = fondo;
        audioS.Play();
    }

    public void Jugar()
    {
        TapPanel.SetActive(true);
        MenuController.SetTrigger("Hide");
        audioS.volume = 0.5f;
        audioS.clip = inicio;
        audioS.Play();
    }

    public void End()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Puntaje()
    {
        audioS.clip = dead;
        audioS.Play();
        parceritosSalvadosText.text = "" + stickyBall.parceritosSalvados.ToString("0");
        asteroidesReunidosText.text = "" + stickyBall.asteroidesReunidos.ToString("0");
        planetasReunidosText.text = "" + stickyBall.planetasReunidos.ToString("0");
        int a = (int)((stickyBall.parceritosSalvados * 10) + (stickyBall.asteroidesReunidos * 20) + (stickyBall.planetasReunidos * 40));
        puntajeTotal.text = "Score: " + a.ToString();
    }
}
