using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;

public class PainterManagerCubes : MonoBehaviour
{
   
    [SerializeField] private CWCarDefiner currentCar;

    [SerializeField] private P3dPaintSphere foamParticlesSphere;
    [SerializeField] private P3dPaintSphere waterParticlesSphere;
    [SerializeField] private P3dPaintSphere fabricPainterSphere;
    [SerializeField] private P3dPaintSphere squeegeeSphere;
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


    public int foamMax;
    public int waterMax;
    public int squeegeMax;
    public int fabricMax;
    
    [SerializeField]  CheckCubesTrigger foamTrigger;
    [SerializeField]  CheckCubesTrigger waterTrigger;
    [SerializeField]  CheckCubesTrigger  squeegeTrigger;
    [SerializeField]  CheckCubesTrigger fabricTrigger;
    
    
    
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

        dirtTexture = carManager.dirtTexture;
        foamTexture = carManager.foamTexture;
        waterTexture = carManager.waterTexture; 
        mainTexture = carManager.mainTexture;
        glassMaskTexture = carManager.glassMaskTexture;

       
        mainPaintableTexture[0].LocalMaskTexture = null;



        waterParticlesSphere.BlendMode= P3dBlendMode.ReplaceCustom(Color.white, waterTexture, Vector4.one);
       
        FoamActive();

    }
    
    
    public void FoamActive()
    {

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
        if (foamMax==foamTrigger.hitNumber && !isFoamFinished)
        {  
            Debug.Log("Foam Finished" );
            OnFoamFinish();
        }
        
        if (  waterMax==waterTrigger.hitNumber  && !isWaterFinished && isFoamFinished )
        {
            Debug.Log("Water Finished");
            OnWaterFinish();
        }
        
        if ( squeegeMax==squeegeTrigger.hitNumber && !isGlassFinished && isWaterFinished && isFoamFinished)
        {   Debug.Log(" Glass Finished");
            OnGlassFinish();
        }
        
        if (fabricMax == fabricTrigger.hitNumber && !isFabricFinished && isGlassFinished && isWaterFinished && isFoamFinished)
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



