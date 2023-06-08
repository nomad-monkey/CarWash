using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;

namespace Unity.Services.Analytics
{
    public class AnalyticsStarter : MonoBehaviour
    {
        void Awake()
        {
            Application.logMessageReceived += OnLogMessageReceived;
        }

        void OnLogMessageReceived(string condition, string stacktrace, LogType type)
        {
           
        }

        void OnDestroy()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        // Analytics Sample
        async void Start()
        {
            await UnityServices.InitializeAsync();
            await AnalyticsService.Instance.CheckForRequiredConsents();

            Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        }

    }
}