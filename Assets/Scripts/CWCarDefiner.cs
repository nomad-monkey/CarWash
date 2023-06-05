using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWCarDefiner : MonoBehaviour
{
  
   public GameObject currentCar;

   public GameObject[] cars;

   [SerializeField] private int carNo;
   
   [SerializeField] PainterManagerCubes _painterManager;
   


  private void Awake()
  {
     
      carNo = 3;

      foreach (GameObject car in cars)
      {
          car.SetActive(false);
      }
      
      cars[carNo].SetActive(true);
      currentCar = cars[carNo];
      
      
  }

   public void NewCar()
   {
       if (cars[carNo + 1] != null)
       {
           carNo += 1;
           
           foreach (GameObject car in cars)
           {
               car.SetActive(false);
           }
      
           cars[carNo].SetActive(true);
           currentCar = cars[carNo];
           
           _painterManager.NewCar();
       }
       
       else
       {
           carNo = 0;
           
           foreach (GameObject car in cars)
           {
               car.SetActive(false);
           }
      
           cars[carNo].SetActive(true);
           
           currentCar = cars[carNo];
           
           _painterManager.NewCar();
       }
       
       
      
      
   }


}
