using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestPlayerController : NetworkBehaviour
{
    private Rigidbody _rigidBody;
    private Animator _animator;
    //private Vector3 _moveVector;
    private Vector2 _moveInput;
    
    private float horizontalAxis;
    private float verticalAxis;

    private NetworkVariable<FixedString64Bytes> _playerName = new();
    
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float rotateSpeed = 20.0f;
    [SerializeField] private float jumpPower = 10.0f;
    [SerializeField] private TextMesh nameTextMesh;

    private void Start()
    {

        _rigidBody = GetComponent<Rigidbody>();
        //_animator = GetComponentInChildren<Animator>();
        
        // _playerName.OnValueChanged += OnChangePlayerName;
        // nameTextMesh.text = _playerName.Value.Value;

    }

    private void Update()
    {
        if (IsOwner)
        {
            SetInputServerRpc(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if (IsServer)
        {
            var moveVector = new Vector3(_moveInput.x, 0, _moveInput.y);
            if (moveVector.magnitude > 1)
            {
                moveVector.Normalize();
            }

            var coefficient = (moveSpeed * moveVector.magnitude - _rigidBody.velocity.magnitude) / Time.deltaTime;
            
            _rigidBody.AddForce(moveVector * coefficient);
            
            if (coefficient > 0)
            {
                transform.localRotation = Quaternion.Lerp(
                    transform.localRotation,
                    Quaternion.LookRotation(moveVector),
                    rotateSpeed * Time.deltaTime
                );
            }

        }
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            Debug.Log($"Player #{NetworkManager.Singleton.LocalClientId} OnNetworkSpawn (server)");
            Spawn();
        }
        if (IsOwner)
        {
            Debug.Log($"Player #{NetworkManager.Singleton.LocalClientId} OnNetworkSpawn");
            
        }
    }

    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(-50f, 50f), 1.0f, Random.Range(-50f, 50f));
        Debug.Log($"spawned at #{transform.position}");
    }
    
    




    #region RPC

    [ServerRpc]
    private void SetInputServerRpc(float horizontal, float vertical)
    {
        _moveInput = new Vector2(horizontal, vertical);
    }

    [ServerRpc(RequireOwnership = true)]
    private void SetPlayerNameServerRpc(string name)
    {
        _playerName.Value = name;
    }

    #endregion
    
}
