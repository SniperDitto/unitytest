
[[network manager]]

init에서 환경 따라 서버/호스트/클라모드 설정해서 실행되도록
```c#
using System.Collections;  
using System.Collections.Generic;  
using Unity.Netcode;  
using Unity.Netcode.Transports.UTP;  
using UnityEngine;  
using UnityEngine.Rendering;  
  
public class Init : MonoBehaviour  
{  
    public UnityTransport unityTransport;  
    public bool isLocal = true;  
    public bool isHost = false;  
    void Start()  
    {        unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();  
        unityTransport.SetConnectionData("127.0.0.1", 7777);  
  
        // if (isLocal)  
        // {        //     unityTransport.SetConnectionData("127.0.0.1", 7777);        // }        // else        // {        //     unityTransport.SetConnectionData("10.33.2.27", 7777);        // }        if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)  
        {            Debug.Log("ServerBuild");  
            NetworkManager.Singleton.StartServer();  
        }        else  
        {  
            if (isHost)  
            {                NetworkManager.Singleton.StartHost();  
            }            else  
            {  
                NetworkManager.Singleton.StartClient();  
            }        }            }  
  
    // Update is called once per frame  
    void Update()  
    {            }  
}
```


빈 오브젝트 만들고 (이름 NetworkManager) NetworkManager랑 UnityTransport 붙이기
플레이어 프리팹 -  오브젝트 암거나 만들어서 NetworkObject 붙이기 후 프리팹으로 저장
