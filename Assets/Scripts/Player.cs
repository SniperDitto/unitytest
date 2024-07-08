using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    
    private float horizontalAxis;
    private float verticalAxis;
    
    private bool wDown;
    private bool jDown;
    private bool isJump;

    private Vector3 moveVector;
    private Rigidbody rigidBody;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal"); //정수로 반환
        verticalAxis = Input.GetAxisRaw("Vertical"); //project settings - input manager에 이름 있음
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVector = new Vector3(horizontalAxis, 0, verticalAxis).normalized;//대각선 방향 보정

        //transform 이동은 물리 충돌을 무시하는 경우가 있다
        //벽 뚫기 방지를 위해 rigidbody - collision detection을 continuous로 변경(대신 cpu를 조금 더 쓴다)
        transform.position += moveVector * (speed * Time.deltaTime * ( wDown ? 0.3f : 1f ));
        
        //rigidbody - freeze rotation 설정으로 관성에 의한 쓰러짐 방지
        
        animator.SetBool("isRun", moveVector != Vector3.zero);
        animator.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        //바라보는 방향으로 회전
        transform.LookAt(transform.position + moveVector);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            isJump = true;
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            animator.SetBool("isJump", true);
            animator.SetTrigger("doJump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }
    }
}
