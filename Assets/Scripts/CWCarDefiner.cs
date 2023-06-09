using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CWCarDefiner : MonoBehaviour
{
  
   public GameObject currentCar;

   public GameObject[] cars;

   public int carNo;
   
   [SerializeField] PainterManagerCubes _painterManager;
   
   [SerializeField] private string nextLevel;

  private void Awake()
  {
      
      PlayerPrefs.SetString("ActiveScene", SceneManager.GetActiveScene().name);
      PlayerPrefs.Save();
      //carNo = 0;
    if (PlayerPrefs.HasKey("ActiveCar"))
      {
          carNo = PlayerPrefs.GetInt("ActiveCar");
      }
      else
      {
          carNo = 0;
      }

     foreach (GameObject car in cars)
      {
          car.SetActive(false);
      }
      
      cars[carNo].SetActive(true);
      currentCar = cars[carNo];
      
      CustomAnalyticsEvents.NewCarEvent(SceneManager.GetActiveScene().name,carNo.ToString());
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
          
           PlayerPrefs.SetInt("ActiveCar", carNo);
           PlayerPrefs.Save();
           
       }
       
       CustomAnalyticsEvents.NewCarEvent(SceneManager.GetActiveScene().name,carNo.ToString());

   }

   public void NewLevel()

   {
       SceneManager.LoadScene(nextLevel);



   }


}
