using System.Collections;
using System.Collections.Generic;
using CW.Common;
using PaintIn3D;
using UnityEngine;

public class CWPainterManager : MonoBehaviour
{
    [SerializeField] private GameObject carToWorkOn;
    [SerializeField] private CWCarDefiner currentCar;
    [SerializeField] private P3dPaintableTexture [] mainPaintableTexture;
   
    [SerializeField] private CWCarManager carManager;
    
    [SerializeField] private Texture dirtTexture;
    [SerializeField] private Texture foamTexture;
    [SerializeField] private Texture waterTexture;
    [SerializeField] private Texture mainTexture;
    [SerializeField] private Texture glassMaskTexture;

    
    [SerializeField] private P3dHitParticles foamParticles;
    [SerializeField] private P3dHitParticles waterParticles;
    
   // [SerializeField] private P3dHitParticles fabricPainter;
   // [SerializeField] private P3dHitParticles  squeegee;
   
   
   [SerializeField] private P3dChangeCounter foamCounter;
   [SerializeField] private P3dChangeCounter waterCounter;
   [SerializeField] private P3dChangeCounter glassCounter ;
   [SerializeField] private P3dChangeCounter fabricCounter;


    private bool isFoamFinished;
    private bool isWaterFinished;
    private bool isGlassFinished;
    private bool isFabricFinished;
    
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        CheckCounters();
    }


    void NewCar()
    {
        isFoamFinished=false;
        isWaterFinished=false;
        isGlassFinished=false;
        isFabricFinished=false;
        
        carToWorkOn=currentCar.currenCar;
        mainPaintableTexture = currentCar.GetComponents<P3dPaintableTexture>();
        
            
            carManager= currentCar.GetComponent<CWCarManager>();

        dirtTexture = carManager.dirtTexture;
        foamTexture = carManager.foamTexture;
        waterTexture = carManager.waterTexture; 
        mainTexture = carManager.mainTexture;
        glassMaskTexture = carManager.glassMaskTexture;

        mainPaintableTexture[0].LocalMaskTexture = mainTexture;
      
        
        foamParticles.enabled = true;
        waterParticles.enabled = false;

        
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
        fabricCounter.MaskTexture = mainTexture;


    }

    public void OnFoamFinish()
    {
        
        
        
        isFoamFinished = true;

    }
    
    
    public void OnWaterFinish()
    {
        
        mainPaintableTexture[0].LocalMaskTexture = glassMaskTexture;
        
        isWaterFinished = true;

    }
    
    public void OnGlassFinish()
    {
        
        
        
        isGlassFinished = true;

    }
    
    
    public void OnFabricFinish()
    {
        
        
        
        isFabricFinished = true;

    }

    public void OnCarFinished()
    {
        
        
        
    }

    void CheckCounters()
    {
        if (foamCounter.Count == 0 && !isFoamFinished)
        {
            OnFoamFinish();
        }
        
        if (waterCounter.Count == 0 && !isWaterFinished)
        {
            OnWaterFinish();
        }
        
        if (glassCounter.Count == 0 && !isGlassFinished)
        {
            OnGlassFinish();
        }
        
        if (fabricCounter.Count == 0 && !isFabricFinished)
        {
            OnFabricFinish();
        }

        if (isFoamFinished&&isWaterFinished&&isGlassFinished&&isFabricFinished)
        {
          Debug.Log("Car Finished");

          OnCarFinished();
        }
        
        
        
    }






}

