using System;
using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;

public class PainterManagerCubes : MonoBehaviour
{
   
    [SerializeField] public CWCarDefiner carDefiner;

    [SerializeField] private float foamRadius;
    [SerializeField] private float waterRadius;
    [SerializeField] private float dryerRadius;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip tickClip;
    [SerializeField] private AudioClip finishClip;
    
    private List <GameObject>waterCubes;
    private List <GameObject> dryerCubes;
    private List <GameObject> foamCubes;

    private P3dPaintableTexture [] mainPaintableTexture;
    private GameObject carToWorkOn;
    private CWCarManager carManager;
    
    

    public bool isFoamFinished;
    public bool isWaterFinished;
    public bool isDryerFinished;
    public bool isCarFinished;

    public int foamMax;
    public  int waterMax;
    public int dryerMax;

    [SerializeField] private bool isDryerSponge;
    
    [SerializeField] private P3dPaintSphere dryerSphere;
    [SerializeField] private P3dPaintSphere waterSphere;
    [SerializeField] private P3dPaintSphere foamSphere;

    [SerializeField] private Texture transparentTexture;
    
    [SerializeField] public RayPainting foamPainter;
    [SerializeField] public RayPainting waterPainter;
    [SerializeField] public RayPainting dryerPainter;

    private void Awake()
    {
        
    }


    void Start()
    {
     
        isFoamFinished = false;
        isWaterFinished = false;
        isDryerFinished = false;
        NewCar();
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckCounters();
       
    }


    public void NewCar()
    {
        isFoamFinished = false;
        isWaterFinished = false;
        isDryerFinished = false;
        isCarFinished = false;

        foamPainter.hitNumber = 0;
        dryerPainter.hitNumber = 0;
        waterPainter.hitNumber = 0;
        carToWorkOn = carDefiner.currentCar;

        carManager= carToWorkOn.GetComponent<CWCarManager>();

        dryerCubes = carManager.dryerCubes;
        waterCubes = carManager.waterCubes;
        foamCubes = carManager.foamCubes;

        foamMax = foamCubes.Count;
        waterMax = waterCubes.Count;
        dryerMax = dryerCubes.Count;

        foreach (GameObject cube in foamCubes)
        { cube.SetActive(false); }
        
        foreach (GameObject cube in waterCubes)
        { cube.SetActive(false); }
        
        foreach (GameObject cube in dryerCubes)
        { cube.SetActive(false); }

        
        FoamActive();
    }
    
    
    public void FoamActive()
    {

        dryerSphere.Radius = 0;
        waterSphere.Radius=0;
        foamSphere.Radius= foamRadius;
      
        if (foamCubes.Count > 0)
        {
            foreach (GameObject cube in foamCubes)
            { cube.SetActive(true); }
        }
        
    }

    public void OnFoamFinish()
    {
        source.PlayOneShot(tickClip);
        isFoamFinished = true;
        WaterActive();
    }
    
    
    public void WaterActive()
    { 
        
        dryerSphere.Radius=0;
      foamSphere.Radius= foamRadius;
      waterSphere.Radius = waterRadius;
      
      if (waterCubes.Count> 0)
      {
          foreach (GameObject cube in waterCubes)
          { cube.SetActive(true); }
      }
       

    }
    
    
    public void OnWaterFinish()
    { 
        DryerActive();
        isWaterFinished = true;
        source.PlayOneShot(tickClip);
    }
    
    public void DryerActive()
    {
        dryerSphere.Radius = dryerRadius;
        foamSphere.Radius= foamRadius;
        waterSphere.Radius = waterRadius;
        
        if (dryerCubes.Count> 0)
        {
            foreach (GameObject cube in dryerCubes)
            { cube.SetActive(true); }
        }
        
      
    }
    
    public void OnDryerFinish()
    {
        isDryerFinished = true;
        source.PlayOneShot(finishClip);

    }


    public void OnCarFinished()
    {
        isCarFinished = true; 
        Debug.Log("Car Finished");
        
    }

  
    
    void CheckCounters()
    {
        if (foamMax==foamPainter.hitNumber && !isFoamFinished)
        {  
            Debug.Log("Foam Finished" );
            OnFoamFinish();
        }
        
        if (  waterMax==waterPainter.hitNumber  && !isWaterFinished && isFoamFinished )
        {
            Debug.Log("Water Finished");
            OnWaterFinish();
        }
        
        if ( dryerMax==dryerPainter.hitNumber && !isDryerFinished && isWaterFinished && isFoamFinished && !isDryerSponge)
        {   Debug.Log("Dryer Finished");
            OnDryerFinish();
        }
        
        if ( dryerPainter.hitNumber>(dryerMax/2) && !isDryerFinished && isWaterFinished && isFoamFinished && isDryerSponge)
        {   Debug.Log("Dryer Finished");

            carToWorkOn.GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", transparentTexture);
            OnDryerFinish();
        }


        if (isFoamFinished && isWaterFinished && isDryerFinished && !isCarFinished)
        {
          Debug.Log("Car Finished");

          OnCarFinished();
        }
        
        
        
        
        
    }






}



