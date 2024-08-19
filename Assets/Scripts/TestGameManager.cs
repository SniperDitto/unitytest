using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.Rendering;

public class TestGameManager : MonoBehaviour
{
    
    private void Awake()
    {
        NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;

        Application.targetFrameRate = 60;
    }
    
    private void Start()
    {

        if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
        {
            StartServer();
        }
        else
        {
#if UNITY_SERVER
        if (!NetworkManager.Singleton.IsServer)
        {
            StartServer();
        }
#endif
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("10.33.3.10", 7777);
            NetworkManager.Singleton.StartClient();
        }
    }

    void StartServer()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("0.0.0.0", 7777);
        NetworkManager.Singleton.StartServer();
    }
    
}
