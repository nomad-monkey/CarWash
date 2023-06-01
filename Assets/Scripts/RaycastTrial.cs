using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrial : MonoBehaviour
{
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,2, 6))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           
             
            if (hit.transform.gameObject.layer == 6)
            { 
                Destroy(hit.collider);
                Destroy(hit.transform.gameObject);
                Debug.Log("Did Hit");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }
}
