using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
namespace Unity.Services.Analytics
{
public class CustomAnalyticsEvents : MonoBehaviour
{



    public static void NewCarEvent (string sceneName, int carNo)
    {
        var parameters = new Dictionary<string, object>
        {
            { "SceneName " + sceneName, "CarNo " + carNo }
        };

        AnalyticsService.Instance.CustomData("NewCarEvent", parameters);
    }
    
    
    
   
}
}