using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanced : MonoBehaviour {

    private Transform player;
    private bool cogido = false;
    private bool alejandose = false;
    private float angle;
    private float radius = 5f;
    private Vector3 pos;
    private AudioSource audioS;
    private ParticleSystem ps;
    private Collider coll;
    public GameObject lookme;

    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindWithTag("Player").transform;
        audioS = GetComponent<AudioSource>();
        coll = GetComponent<Collider>();
        if (GetComponent<ParticleSystem>())
        {
            ps = GetComponent<ParticleSystem>();
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(this.tag == "Sticky1" && stickyBall.size >= 10 && cogido == false)
        {
            if(Vector3.Distance(transform.position, player.position) < 10)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime);
            }
        }
        if (this.tag == "Sticky2" && stickyBall.size >= 80 && cogido == false)
        {
            if (Vector3.Distance(transform.position, player.position) < 10)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime);
            }
        }
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) > 80)
            {
                Destroy(this.gameObject);
            }
        }
        if(alejandose == true)
        {
            transform.position = Vector3.Lerp(transform.position, pos, 0.03f);
        }
    }

    private void OnTransformParentChanged()
    {
        cogido = !cogido;
        if(cogido == true)
        {
            if (ps)
            {
                lookme.SetActive(false);
                ps.Play();
            }
        }
        if (cogido == false)
        {
            audioS.Play();
            lookme.SetActive(true);
            StartCoroutine(activarCollider());
            alejandose = true;
        }
    }
    IEnumerator activarCollider()
    {
        angle = Random.Range(0, 360);
        pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Random.Range(radius, radius + 10) + transform.position;
        yield return new WaitForSeconds(1f);
        coll.enabled = true;
        alejandose = false;
    }
}
