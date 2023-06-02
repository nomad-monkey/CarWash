using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageText : MonoBehaviour
{
   [SerializeField] PainterManagerCubes painterManager; 
   [SerializeField] private Text taskName;
   [SerializeField] private Text percentageText;

   [SerializeField] private GameObject nextCarButton;

   
 
   
   private void Update()
   {
      nextCarButton.SetActive(painterManager.isCarFinished);
      
      if (!painterManager.isFoamFinished && !painterManager.isWaterFinished && !painterManager.isDryerFinished && !painterManager.isCarFinished)
      {

         taskName.text = "Foam";
         percentageText.text = painterManager.foamPainter.hitNumber + "/" + painterManager.foamMax ;
      }
      else if (painterManager.isFoamFinished && !painterManager.isWaterFinished && !painterManager.isDryerFinished &&
               !painterManager.isCarFinished)
      {
         taskName.text = "Water";
         percentageText.text = painterManager.waterPainter.hitNumber + "/" + painterManager.waterMax ;
      }
      
      else if (painterManager.isFoamFinished && painterManager.isWaterFinished && !painterManager.isDryerFinished &&
               !painterManager.isCarFinished)
      {
         
         taskName.text = "Dryer";
         percentageText.text = painterManager.dryerPainter.hitNumber + "/" + painterManager.dryerMax ; 
      }
      
      
      else if (painterManager.isFoamFinished && painterManager.isWaterFinished && painterManager.isDryerFinished &&
               painterManager.isCarFinished)
      {
         
         taskName.text = "Finished";
         percentageText.text =  "3/3"  ; 
      }
      
      
     
   }
}
