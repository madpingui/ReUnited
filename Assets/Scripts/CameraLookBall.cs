using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookBall : MonoBehaviour {

    public GameObject ball;
    private Vector3 offset;

	void Start () 
    {
        offset = new Vector3(0, 1.5f, 0);
	}

	void Update () 
    {
        if(ball != null)
        {
            transform.LookAt(ball.transform.position + offset);
        }
	}
}
