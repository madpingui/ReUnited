using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esferita : MonoBehaviour {

    public List<Transform> parceritosEntrados = new List<Transform>();
    public GameObject flechita;

    private void Update()
    {
        if(parceritosEntrados.Count <= 0)
        {
            flechita.SetActive(false);
        }
        else
        {
            Transform go = GetClosestEnemy(parceritosEntrados, transform);
            flechita.transform.LookAt(go);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sticky1"))
        {
            flechita.SetActive(true);
            parceritosEntrados.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sticky1"))
        {
            parceritosEntrados.Remove(other.transform);
        }
    }

    Transform GetClosestEnemy(List<Transform> enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;

        foreach (Transform potentialTarget in enemies)
        {
            if(potentialTarget != null)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
            else
            {
                break;
            }
           
        }
        if (bestTarget != null)
        {
            return bestTarget;
        }
        else
        {
            
            return bestTarget;
        }
        
    }
}
