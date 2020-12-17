using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanced2 : MonoBehaviour {

    private Transform player;

    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) > 90)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
