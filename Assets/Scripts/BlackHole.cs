using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public float GRAVITY_PULL;
    public static float GravityRadius;

    void Awake()
    {
        GravityRadius = GetComponent<SphereCollider>().radius;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            float gravityIntensity = (Vector3.Distance(transform.position, other.transform.position)) / GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * GRAVITY_PULL * Time.smoothDeltaTime);
        }
    }
}
