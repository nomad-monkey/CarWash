using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PercentageText : MonoBehaviour
{
   [SerializeField] PainterManagerCubes painterManager; 
   [SerializeField] private Text taskName;
   [SerializeField] private TMP_Text percentageText;

   [SerializeField] private GameObject nextCarButton;
  
   
   [SerializeField] private GameObject[] taskCheck;
   
 
   
   private void Update()
   {
      nextCarButton.SetActive(painterManager.isCarFinished);
      
      if (!painterManager.isFoamFinished && !painterManager.isWaterFinished && !painterManager.isDryerFinished && !painterManager.isCarFinished)
      {  
         taskCheck[0].SetActive(false);
         taskCheck[1].SetActive(false);
         taskCheck[2].SetActive(false);
         
         taskName.text = "Foam";
         
         percentageText.text =  "%" + (painterManager.foamPainter.hitNumber*100/painterManager.foamMax ) ;
      }
      else if (painterManager.isFoamFinished && !painterManager.isWaterFinished && !painterManager.isDryerFinished &&
               !painterManager.isCarFinished)
      {  
         taskCheck[0].SetActive(true);
         taskName.text = "Water";
         percentageText.text =  "%" + (100*painterManager.waterPainter.hitNumber/ painterManager.waterMax);
      }
      
      else if (painterManager.isFoamFinished && painterManager.isWaterFinished && !painterManager.isDryerFinished &&
               !painterManager.isCarFinished)
      {
         taskCheck[1].SetActive(true);
         taskName.text = "Dryer";
         percentageText.text = "%"+ (100*painterManager.dryerPainter.hitNumber / painterManager.dryerMax) ; 
      }
      
      
      else if (painterManager.isFoamFinished && painterManager.isWaterFinished && painterManager.isDryerFinished &&
               painterManager.isCarFinished)
      {
         taskCheck[2].SetActive(true);
         taskName.text = "Finished";
         percentageText.text =  "3/3"  ; 
      }
      
      
     
   }
}
