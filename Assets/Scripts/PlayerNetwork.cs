using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Transform spawnTestObject;
    private Transform spawnObjTransform;
    
    private NetworkVariable<NakjiData> _nakjiData = new NetworkVariable<NakjiData>
    (
        value:new NakjiData()
        {
            Level = 1,
            RandomNumber = 0,
            IsHungry = false
        },
        readPerm:NetworkVariableReadPermission.Everyone, 
        writePerm:NetworkVariableWritePermission.Owner
    );
    
    public struct NakjiData : INetworkSerializable
    {
        public int Level;
        public int RandomNumber;
        public bool IsHungry;
        public FixedString128Bytes Message;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Level);
            serializer.SerializeValue(ref RandomNumber);
            serializer.SerializeValue(ref IsHungry);
            serializer.SerializeValue(ref Message);
        }
    }
    
    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T)) _nakjiData.Value = new NakjiData()
        {
            Level = 1,
            RandomNumber = Random.Range(0, 100),
            IsHungry = false,
            Message = $"Hello! I'm nakji {OwnerClientId}."
        };
        if(Input.GetKeyDown(KeyCode.R)) TestServerRpc(new ServerRpcParams());
        if(Input.GetKeyDown(KeyCode.F)) TestClientRpc(new ClientRpcParams()
        {
            //1번낙지에게만 보내는 rpc
            Send = new ClientRpcSendParams(){TargetClientIds = new List<ulong>(){1}}
        });

        if (Input.GetKeyDown(KeyCode.G))
        {
            spawnObjTransform = Instantiate(spawnTestObject);
            spawnObjTransform.GetComponent<NetworkObject>().Spawn(true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(spawnObjTransform.gameObject);
        }
        
        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDirection.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDirection.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDirection.x = +1f;

        float moveSpeed = 10f;
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);

    }

    [ServerRpc]
    private void TestServerRpc(ServerRpcParams serverRpcParams)
    {
        Debug.Log($"TestServerRpc : nakji {OwnerClientId}");
        Debug.Log($"paramsSend : {serverRpcParams.Send.ToString()}");
        Debug.Log($"paramsReceived : {serverRpcParams.Receive.ToString()}");
    }

    [ClientRpc]
    private void TestClientRpc(ClientRpcParams clientRpcParams)
    {
        Debug.Log($"TestClientRpc : nakji {OwnerClientId}");
        Debug.Log($"paramsSend : {clientRpcParams.Send.ToString()}");
        Debug.Log($"paramsReceived : {clientRpcParams.Receive.ToString()}");
    }

    public override void OnNetworkSpawn()
    {
        Debug.Log($"nakji {OwnerClientId} entered.");
        _nakjiData.OnValueChanged += (NakjiData prevVal, NakjiData newVal) =>
        {
            Debug.Log($"nakji {OwnerClientId}'s random number changed : {prevVal.RandomNumber}->{newVal.RandomNumber}");
            Debug.Log($"nakji {OwnerClientId} : {newVal.Message}");
        };
    }

    public override void OnNetworkDespawn()
    {
        Debug.Log($"nakji {OwnerClientId} is gone.");
    }
    
}
