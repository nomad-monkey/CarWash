using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using PaintIn3D;
using UnityEngine;

public class RayPainting : MonoBehaviour
{

    [SerializeField] private Grabbable _grabbable;
    
    [SerializeField] private GameObject hitPainter;
    
    [SerializeField] private int _layerMask;

    public int hitNumber;
    private void FixedUpdate()
    {

        PaintWithTrigger();

    }

    public void PaintWithTrigger()
        {

            if (_grabbable.BeingHeld && InputBridge.Instance.RightTrigger>0.1f)
            {
                Debug.Log("hold");
               
		
                RaycastHit hitInfo;


                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitInfo,Mathf.Infinity))
                {
                    Debug.Log("hit");
                    hitPainter.SetActive(true);
                    hitPainter.transform.position = hitInfo.point;

                    var paintObject = hitInfo.transform.GetComponent<P3dPaintable>();
                   
                    if(paintObject != null)
                    {
                        
                       
                    }

                    if (hitInfo.transform.gameObject.layer == _layerMask)
                    {
                        Debug.Log("HitCube");
                        GameObject objectToDestroy = hitInfo.transform.gameObject;
                        objectToDestroy.layer = 0;
                        Destroy(objectToDestroy.GetComponent(typeof(Collider)));
                        Destroy(objectToDestroy);
                        
                        hitNumber++;
                    }
					
                    
                }
			
			
            }
            else
            {
               
                hitPainter.SetActive(false);
                
            }
        }
}