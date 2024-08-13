using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.Rendering;

public class TestGameManager : MonoBehaviour
{
    private void Start()
    {

        if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("127.0.0.1", 7777);
            NetworkManager.Singleton.StartServer();
        }
        else
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("127.0.0.1", 7777);
            NetworkManager.Singleton.StartClient();
        }
    }

    // private void OnGUI()
    // {
    //     GUILayout.BeginArea(new Rect(10, 10, 300, 300));
    //     if (!_networkManager.IsClient && _networkManager.IsServer)
    //     {
    //         StartButtons();
    //     }
    //     else
    //     {
    //         StatusLabels();
    //         SubmitNewPosition();
    //     }
    //
    //     GUILayout.EndArea();
    // }
    //
    // void StartButtons()
    // {
    //     if (GUILayout.Button("Host")) _networkManager.StartHost();
    //     if (GUILayout.Button("Client")) _networkManager.StartClient();
    //     if (GUILayout.Button("Server")) _networkManager.StartServer();
    // }
    //
    // void StatusLabels()
    // {
    //     var mode = _networkManager.IsHost ? "Host" : _networkManager.IsServer ? "Server" : "Client";
    //     
    //     GUILayout.Label("Transport: "+_networkManager.NetworkConfig.NetworkTransport.GetType().Name);
    //     GUILayout.Label("Mode: "+mode);
    // }
    //
    // void SubmitNewPosition()
    // {
    //     if (GUILayout.Button(_networkManager.IsServer ? "Move" : "Request Position Change"))
    //     {
    //         if (_networkManager.IsServer && !_networkManager.IsClient)
    //         {
    //             foreach (ulong uid in _networkManager.ConnectedClientsIds)
    //             {
    //                 _networkManager.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<TestGamePlayer>().Move();
    //             }
    //         }
    //         else
    //         {
    //             var playerObject = _networkManager.SpawnManager.GetLocalPlayerObject();
    //             var player = playerObject.GetComponent<TestGamePlayer>();
    //             player.Move();
    //         }
    //     }
    // }
    
}
