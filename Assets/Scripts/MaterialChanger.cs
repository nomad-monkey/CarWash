using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChanger : MonoBehaviour
{

    
    private Material carTransparentMaterial;
   
    
    
    [SerializeField] private MeshRenderer[] quadRenderers;

    private void Start()
    {
        carTransparentMaterial = gameObject.GetComponent<MeshRenderer>().materials[2];
      
       // quadRenderer.material = carTransparentMaterial;

        Debug.Log(carTransparentMaterial.GetTexture("_MainTex").name);
        Texture carTexture= carTransparentMaterial.GetTexture("_MainTex");
       
        //quadRenderer.material.SetTexture("_MainTex",carTexture);

        foreach (MeshRenderer renderer in quadRenderers)
        {
            
            renderer.material = carTransparentMaterial;
            renderer.material.SetTexture("_MainTex",carTexture);
        }


    }
}
