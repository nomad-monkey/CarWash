using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class SprayPosition : MonoBehaviour
{

    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform foamGun;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform waterGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputBridge.Instance.BButtonDown)
        {

            waterGun.transform.position = rightHand.position;
           
        }
        
        
        if (InputBridge.Instance.XButtonDown)
        {

            waterGun.transform.position = rightHand.position;
            
        }
    }
}
