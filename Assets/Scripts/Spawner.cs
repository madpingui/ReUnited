using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] asteroides;
    public GameObject[] parceritos;
    public GameObject[] planetas;
    public GameObject[] soles;
    public GameObject[] agujerosNegros;
    private float radius = 8f;

    private float respawnTime = 0.8f;
    private float readyToRespawn;

    private Vector3 originPoint;

    private float angle;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () 
    {
        if(Time.time > readyToRespawn)
        {
            if (GameController.Instance.once == true)
            {
                int a = Random.Range(0,101);
                angle = Random.Range(0, 360);
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Random.Range(radius, radius + 40);

                if (a <= 35)
                {
                    Instantiate(parceritos[Random.Range(0, parceritos.Length)], transform.position + pos, Quaternion.identity);
                }
                else if(a > 35 && a <= 65)
                {
                    Instantiate(asteroides[Random.Range(0, asteroides.Length)], transform.position + pos, Quaternion.identity);
                }
                else if (a > 65 && a <= 85)
                {
                    Instantiate(planetas[Random.Range(0, planetas.Length)], transform.position + pos, Quaternion.identity);
                }
                else if (a > 85 && a <= 95)
                {
                    Instantiate(soles[Random.Range(0, soles.Length)], transform.position + pos, Quaternion.identity);
                }
                else if (a > 95 && a <= 100)
                {
                    Instantiate(agujerosNegros[Random.Range(0, agujerosNegros.Length)], transform.position + pos, Quaternion.identity);
                }

                readyToRespawn = Time.time + respawnTime;

            }
        }
    }
}
