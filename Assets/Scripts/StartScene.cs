using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
   
    [SerializeField] private GameObject continueButton;
    void Start()
    {
        if (PlayerPrefs.HasKey("ActiveScene"))
        {
           
            continueButton.SetActive(true);
            
        }
        else
        {
            
            continueButton.SetActive(false);
            
        }
    }

    // Update is called once per frame
    public void Continue()
    {
       
        SceneManager.LoadScene( PlayerPrefs.GetString("ActiveScene"));
        
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
        
        PlayerPrefs.DeleteKey("ActiveCar");
        
        PlayerPrefs.Save();

    }
}
