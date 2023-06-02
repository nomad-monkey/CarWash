using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class SprayPosition : MonoBehaviour
{
    [SerializeField] private Grabbable _grabbable;
    
    [SerializeField] private Transform initTransform;
    
    [SerializeField] float interval;
    
    // Start is called before the first frame update
    void Awake()
    {
        initTransform = transform.transform;
        transform.GetComponent<Rigidbody>().useGravity = false;

    }

    private void FixedUpdate()
    {
       interval += Time.deltaTime;
       Debug.Log(interval);
    }

    // Update is called once per frame
    void Update()
    {
        if (interval % 5 == 0)
        {
            
            if (!_grabbable.BeingHeld && transform.position != initTransform.position )
            {
                transform.position = initTransform.position;
                transform.rotation = initTransform.rotation;

                transform.GetComponent<Rigidbody>().useGravity = false;


            }

            if (_grabbable.BeingHeld)
            {
                transform.GetComponent<Rigidbody>().useGravity = true;
           
            }
            
            
            
        }
       
          
      
    }
}
