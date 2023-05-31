using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCubesTrigger : MonoBehaviour
{
    public PainterManagerCubes managerCubes;
    public int hitNumber;
    public bool isRaycast;

    public Text percentageText;
    public PainterType Painter { set { painter = value; } get { return painter; } } [SerializeField] private PainterType painter;
    public enum PainterType
    {
        Foam,
        Water,
        Squeege,
        Fabric
    }
    void Start()
    {
        hitNumber = 0;
    }

    
    void Update()
    {
        if (painter == PainterType.Squeege)
        {
            CheckforHitsSqueege();

        }
        if (painter == PainterType.Fabric)
        {
            
            CheckforHitsSFabric();
        }
    }

    private void FixedUpdate()
    {
        
    }


    public void CheckforHitsFoam()
    {
        percentageText.text = (hitNumber + "/" + managerCubes.foamMax);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,2, 6))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           
             
            if (hit.transform.gameObject.layer == 6)
            { hitNumber++;
                Destroy(hit.collider);
                Destroy(hit.transform.gameObject);
                Debug.Log("Did Hit");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

    }
    
    
    public void CheckforHitsWater()
    {
        percentageText.text = (hitNumber + "/" + managerCubes.waterMax);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,2, 7))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            
             
            if (hit.transform.gameObject.layer == 7)
            { hitNumber++;
                Destroy(hit.collider);
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

    }
    
    
    public void CheckforHitsSqueege()
    {
        percentageText.text = (hitNumber + "/" + managerCubes.squeegeMax);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,0.3f, 8))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
           
            if (hit.transform.gameObject.layer == 8)
            {
                Debug.Log("Did Hit");
                hitNumber++;
                Destroy(hit.collider);
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }

    }
    
    
    
    public void CheckforHitsSFabric()
    {
        percentageText.text = (hitNumber + "/" + managerCubes.fabricMax);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit,0.3f, 9))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
           
           
            if (hit.transform.gameObject.layer == 9)
            { hitNumber++;
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
