using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
namespace Unity.Services.Analytics
{
public class CustomAnalyticsEvents : MonoBehaviour
{



    public static void NewCarEvent (string sceneName, string carNumber)
    {
        var parameters = new Dictionary<string, object>
        {
            { sceneName,  carNumber }
        };

        AnalyticsService.Instance.CustomData("NewCarEvent", parameters);
    }
    
    
    
   
}
}