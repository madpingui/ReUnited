using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stickyBall : MonoBehaviour {

    private float forceSwipe = 150;
    public Swipe swipeController;

    private AudioSource audioS;

    private float nivel1 = 80f;
    private float nivel2 = 400f;
    private bool nivel1Desbloq;
    private bool nivel2Desbloq;
    public Esferita esferitascript;
    public AudioClip slide, stick;

    public GameObject sizeUp;

    public GameObject cameraReference;
    float distanceToCamera = 3;

    public static float size = 10;

    public Text sizeBall;

    private Rigidbody rb;

    public static float parceritosSalvados ;
    public static float asteroidesReunidos;
    public static float planetasReunidos ;

    public static stickyBall Instance { set; get; }

    // Use this for initialization
    void Start ()
    {
        parceritosSalvados = 0;
        asteroidesReunidos = 0;
        planetasReunidos = 0;
        size = 10;
        Instance = this;
        audioS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Swipe.OnSwipe += SwipeStickyBall;
    }

    private void FixedUpdate()
    {
        if (size >= nivel1 && nivel1Desbloq == false)
        {
            sizeUp.SetActive(true);
            nivel1Desbloq = true;
        }
        if (size >= nivel2 && nivel2Desbloq == false)
        {
            sizeUp.SetActive(true);
            nivel2Desbloq = true;
        }

        cameraReference.transform.position = Vector3.Slerp(cameraReference.transform.position, new Vector3(0, distanceToCamera * (1 + rb.velocity.magnitude/10), -distanceToCamera * (1 + rb.velocity.magnitude/10)) + this.transform.position, 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Sticky1"))
        {
            other.gameObject.tag = "Cogido";
            esferitascript.parceritosEntrados.Remove(other.transform);
            //Grow the sticky ball
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            size += Random.Range(7, 13);
            distanceToCamera += 0.2f;
            other.enabled = false;
            sizeBall.text = "Mass: " + size.ToString();
            other.GetComponent<Animator>().SetTrigger("Cogido");
            audioS.clip = stick;
            audioS.pitch = Random.Range(0.9f, 1.1f);
            audioS.Play();

            //Becomes child of sticky ball
            other.transform.SetParent(this.transform);
        }

        if (other.transform.CompareTag("Sticky2"))
        {
            if (size >= nivel1)
            {
                //Grow the sticky ball
                transform.localScale += new Vector3(0.08f, 0.08f, 0.08f);
                size += Random.Range(50, 70);
                distanceToCamera += 0.3f;
                other.enabled = false;
                sizeBall.text = "Mass: " + size.ToString();

                //Becomes child of sticky ball
                other.transform.SetParent(this.transform);
            }
            else
            {
                int hijos = transform.childCount;

                rb.velocity = -rb.velocity;
                for (int i = 0; i < Mathf.RoundToInt(hijos / 3); i++)
                {
                    GameObject go = transform.GetChild(Random.Range(2, transform.childCount)).gameObject;
                    go.transform.parent = null;
                    if (go.tag == "Cogido")
                    {
                        go.tag = "Sticky1";
                        esferitascript.parceritosEntrados.Add(go.transform);
                        size -= Random.Range(5, 10);
                    }
                    else if (go.tag == "Sticky2")
                    {
                        size -= Random.Range(40, 60);
                    }
                    else if (go.tag == "Sticky3")
                    {
                        size -= Random.Range(80, 100);
                    }
                    sizeBall.text = "Mass: " + size.ToString();
                }
            }
        }

        if (other.transform.CompareTag("Sticky3"))
        {
            if (size >= nivel2)
            {
                //Grow the sticky ball
                transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);
                size += Random.Range(100, 150);
                distanceToCamera += 0.4f;
                other.enabled = false;
                sizeBall.text = "Mass: " + size.ToString();

                //Becomes child of sticky ball
                other.transform.SetParent(this.transform);
            }
            else
            {
                int hijos = transform.childCount;

                rb.velocity = -rb.velocity;
                for (int i = 0; i < Mathf.RoundToInt(hijos / 3); i++)
                {
                    GameObject go = transform.GetChild(Random.Range(2, transform.childCount)).gameObject;
                    go.transform.parent = null;
                    if (go.tag == "Cogido")
                    {
                        esferitascript.parceritosEntrados.Add(go.transform);
                        go.tag = "Sticky1";
                        size -= Random.Range(5, 10);
                    }
                    else if (go.tag == "Sticky2")
                    {
                        size -= Random.Range(40, 60);
                    }
                    else if (go.tag == "Sticky3")
                    {
                        size -= Random.Range(80, 100);
                    }
                    sizeBall.text = "Mass: " + size.ToString();
                }
            }
        }

        if (other.transform.CompareTag("Sol"))
        {
           // Destroy(this.gameObject);
            GameController.Instance.EndPanel.SetActive(true);
            Time.timeScale = 0;
            Die();
        }
        if (other.transform.CompareTag("Hole"))
        {
            rb.velocity = Vector3.zero;
            GetComponent<Animator>().SetTrigger("Die");
        }
    }

    private void SwipeStickyBall(Direction direction)
    {
        if (GameController.Instance.once != true)
            return;

        switch (direction)
        {
            case Direction.Left:
                rb.AddForce(new Vector3(-forceSwipe, 0, 0));
                rb.AddTorque(new Vector3(0, 0, forceSwipe));
                break;
            case Direction.Right:
                rb.AddForce(new Vector3(forceSwipe, 0, 0));
                rb.AddTorque(new Vector3(0, 0, -forceSwipe));
                break;
            case Direction.Down:
                rb.AddForce(new Vector3(0, 0, -forceSwipe));
                rb.AddTorque(new Vector3(-forceSwipe, 0, 0));
                break;
            case Direction.Up:
                rb.AddForce(new Vector3(0, 0, forceSwipe));
                rb.AddTorque(new Vector3(forceSwipe, 0, 0));
                break;
        }

        audioS.clip = slide;
        audioS.pitch = Random.Range(0.9f, 1.1f);
        audioS.Play();
    }

    public void Die()
    {
        GameController.Instance.EndPanel.SetActive(true);
        Time.timeScale = 0;
        foreach (Transform child in transform)
        {
            if(child.tag == "Cogido")
            {
                parceritosSalvados++;
            }
            else if (child.tag == "Sticky2")
            {
                asteroidesReunidos++;
            }
            else if (child.tag == "Sticky3")
            {
                planetasReunidos++;
            }
        }
        GameController.Instance.Puntaje();
    }
}
