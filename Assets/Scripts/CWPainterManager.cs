using System;
using System.Collections;
using System.Collections.Generic;
using CW.Common;
using PaintIn3D;
using UnityEngine;

public class CWPainterManager : MonoBehaviour
{
  
    [SerializeField] private CWCarDefiner currentCar;
    [SerializeField] private P3dHitParticles foamParticles;
    [SerializeField] private P3dPaintSphere foamParticlesSphere;
    
    [SerializeField] private P3dHitParticles waterParticles;
    [SerializeField] private P3dPaintSphere waterParticlesSphere; 
    
    [SerializeField] private P3dHitBetween fabricPainter;
    [SerializeField] private P3dPaintSphere fabricPainterSphere;
    [SerializeField] private P3dHitBetween squeegee;
    [SerializeField] private P3dPaintSphere squeegeeSphere;
    
    
    [SerializeField] private P3dChangeCounter foamCounter;
    [SerializeField] private P3dChangeCounter waterCounter;
    [SerializeField] private P3dChangeCounter glassCounter ;
    [SerializeField] private P3dChangeCounter fabricCounter;
    
    [SerializeField] private GameObject ofoamCounter;
    [SerializeField] private GameObject owaterCounter;
    [SerializeField] private GameObject oglassCounter ;
    [SerializeField] private GameObject ofabricCounter;
    
    
    [SerializeField] private GameObject ofoamCounterText;
    [SerializeField] private GameObject owaterCounterText;
    [SerializeField] private GameObject oglassCounterText;
    [SerializeField] private GameObject ofabricCounterText;
    
    
    [SerializeField] private P3dChannelCounter glassCounterAlpha ;
    [SerializeField] private P3dChannelCounter fabricCounterAlpha;
    
    [SerializeField] private Texture transparentTexture;
   
    
    [SerializeField] private float foamRadius;
    [SerializeField] private float waterRadius;
    [SerializeField] private float fabricRadius;
    [SerializeField] private float squeegeeRadius;
    
    
    private P3dPaintableTexture [] mainPaintableTexture;
    private CWCarManager carManager;
    private GameObject carToWorkOn;
    private Texture dirtTexture;
    private Texture foamTexture;
    private Texture waterTexture;
    private Texture mainTexture; 
    private Texture glassMaskTexture;

    private bool isFoamFinished;
    private bool isWaterFinished;
    private bool isGlassFinished;
    private bool isFabricFinished;
    private bool isCarFinished;
    private bool newCar;
    
    

    private void Awake()
    {
         foamCounter.enabled=false;
         waterCounter.enabled=false;
         glassCounter.enabled=false;
         fabricCounter.enabled=false;
    }
    
    void Start()
    {
        newCar = false;
        isFoamFinished = false;
        isWaterFinished = false;
        isGlassFinished = false;
        isFabricFinished = false;
        isCarFinished = false;
        NewCar();
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
     /*   if (!newCar && waterCounter.Count==0)
        {
            newCar = false;
            
        }
        else if (!newCar && waterCounter.Count!=0 )
        {
          NewCar();
        }

        if (newCar)
        {
            CheckCounters();
        }
       */
     
     
        CheckCounters();
       
    }


    void NewCar()
    {
        newCar = true;
        isFoamFinished = false;
        isWaterFinished = false;
        isGlassFinished = false;
        isFabricFinished = false;
        isCarFinished = false;
        
        carToWorkOn = currentCar.currentCar;
       
        mainPaintableTexture = carToWorkOn.GetComponents<P3dPaintableTexture>();
        carManager= carToWorkOn.GetComponent<CWCarManager>();

        /*dirtTexture = carManager.dirtTexture;
        foamTexture = carManager.foamTexture;
        waterTexture = carManager.waterTexture; 
        mainTexture = carManager.mainTexture;
        glassMaskTexture = carManager.glassMaskTexture;*/

       
        mainPaintableTexture[0].LocalMaskTexture = null;



        foamCounter.PaintableTexture = mainPaintableTexture[0];
        foamCounter.MaskTexture = mainTexture;
        foamCounter.Texture = foamTexture;

        waterCounter.PaintableTexture = mainPaintableTexture[0];
        waterCounter.MaskTexture = mainTexture;
        waterCounter.Texture = waterTexture;
        
        glassCounter.PaintableTexture = mainPaintableTexture[0];
        glassCounter.MaskTexture = glassMaskTexture ;
        glassCounter.Texture = mainTexture;
        
        
        fabricCounter.PaintableTexture = mainPaintableTexture[0];
        fabricCounter.MaskTexture = mainTexture;
        fabricCounter.Texture = mainTexture;
        
        glassCounterAlpha.PaintableTexture = mainPaintableTexture[0];
        glassCounterAlpha.MaskTexture = glassMaskTexture;

        fabricCounterAlpha.PaintableTexture=mainPaintableTexture[0];
        fabricCounterAlpha.MaskTexture = mainTexture;
        
        


        waterParticlesSphere.BlendMode= P3dBlendMode.ReplaceCustom(Color.white, waterTexture, Vector4.one);
        foamParticlesSphere.BlendMode= P3dBlendMode.ReplaceCustom(Color.white, foamTexture,Vector4.one);
        
        fabricPainterSphere.BlendMode= P3dBlendMode.ReplaceCustom(Color.white, mainTexture, Vector4.one);
        squeegeeSphere.BlendMode= P3dBlendMode.ReplaceCustom(Color.white, mainTexture,Vector4.one);
       
        FoamActive();

    }
    
    
    public void FoamActive()
    {
      
        
        ofoamCounter.SetActive(true);
        owaterCounter.SetActive(false);
        oglassCounter.SetActive(false);
        ofabricCounter.SetActive(false); 
        ofoamCounterText.SetActive(true);
        owaterCounterText.SetActive(false);
        oglassCounterText.SetActive(false);
        ofabricCounterText.SetActive(false);
        
        squeegeeSphere.Radius = 0;
        fabricPainterSphere.Radius=0;
        foamParticlesSphere.Radius= foamRadius;
        waterParticlesSphere.Radius = 0;
        
        

       
        mainPaintableTexture[0].LocalMaskTexture = null;
    }

    public void OnFoamFinish()
    {
        isFoamFinished = true;
        WaterActive();
    }
    
    
    public void WaterActive()
    {
        mainPaintableTexture[0].LocalMaskTexture = null;
       
       
        ofoamCounter.SetActive(false);
        owaterCounter.SetActive(true);
        oglassCounter.SetActive(false);
        ofabricCounter.SetActive(false);
        
        ofoamCounterText.SetActive(false);
        owaterCounterText.SetActive(true);
        oglassCounterText.SetActive(false);
        ofabricCounterText.SetActive(false);
       
       
       
       squeegeeSphere.Radius = 0;
       fabricPainterSphere.Radius=0;
       foamParticlesSphere.Radius= foamRadius;
       waterParticlesSphere.Radius = waterRadius;
       

    }
    
    
    public void OnWaterFinish()
    {
        SqueegeeActive();
        isWaterFinished = true;
    }
    
    public void SqueegeeActive()
    {
        
        mainPaintableTexture[0].LocalMaskTexture = glassMaskTexture;
      
        
        ofoamCounter.SetActive(false);
        owaterCounter.SetActive(false);
        oglassCounter.SetActive(true);
        ofabricCounter.SetActive(false);
        
        ofoamCounterText.SetActive(false);
        owaterCounterText.SetActive(false);
        oglassCounterText.SetActive(true);
        ofabricCounterText.SetActive(false);
       
       squeegeeSphere.Radius =squeegeeRadius;
       fabricPainterSphere.Radius= 0;
       foamParticlesSphere.Radius= foamRadius;
       waterParticlesSphere.Radius = waterRadius;
    }
    
    public void OnGlassFinish()
    { 
        FabricActive();
        isGlassFinished = true; 
    }
    
   
    public void FabricActive()
    {
        mainPaintableTexture[0].LocalMaskTexture = null;


        ofoamCounter.SetActive(false);
        owaterCounter.SetActive(false);
        oglassCounter.SetActive(false);
        ofabricCounter.SetActive(true);
        
        ofoamCounterText.SetActive(false);
        owaterCounterText.SetActive(false);
        oglassCounterText.SetActive(false);
        ofabricCounterText.SetActive(true);
        
        
      squeegeeSphere.Radius = squeegeeRadius;
      fabricPainterSphere.Radius = fabricRadius;
      foamParticlesSphere.Radius = foamRadius;
      waterParticlesSphere.Radius = waterRadius;
        

    }

    
    public void OnFabricFinish()
    {
        
        mainPaintableTexture[0].LocalMaskTexture = null;
        isFabricFinished = true;

    }
    
   
    public void OnCarFinished()
    {
        isCarFinished = true; 
        Debug.Log("Car Finished");
        
    }

  
    
    void CheckCounters()
    {
        if (foamCounter.Total>0 && 1-foamCounter.Ratio >0.90f && !isFoamFinished)
        {  
            Debug.Log("Foam Finished" + foamCounter.Ratio);
            OnFoamFinish();
        }
        
        if (waterCounter.Total>0 && 1-waterCounter.Ratio >0.90f&& !isWaterFinished && isFoamFinished)
        {
            Debug.Log("Water Finished" + waterCounter.Ratio);
            OnWaterFinish();
        }
        
        if (glassCounter.Total > 0 && 1-glassCounter.Ratio > 0.90f && !isGlassFinished && isWaterFinished && isFoamFinished)
        {   Debug.Log(" Glass Finished");
            OnGlassFinish();
        }
        
        if (fabricCounter.Total >0 && 1-fabricCounter.Ratio > 0.70f && !isFabricFinished && isGlassFinished && isWaterFinished && isFoamFinished)
        {
            Debug.Log(" Fabric Finished");
            OnFabricFinish();
        }

        if (isFoamFinished && isWaterFinished && isGlassFinished && isFabricFinished && !isCarFinished)
        {
          Debug.Log("Car Finished");

          OnCarFinished();
        }



    }






}

