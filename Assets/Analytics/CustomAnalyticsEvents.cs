using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
namespace Unity.Services.Analytics
{
public class CustomAnalyticsEvents : MonoBehaviour
{



    public static void NewCarEvent (string sceneName, string carNo)
    {
        var parameters = new Dictionary<string, object>
        {
            { sceneName,  carNo }
        };

        AnalyticsService.Instance.CustomData("NewCarEvent", parameters);
    }
    
    
    
   
}
}