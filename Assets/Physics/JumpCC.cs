using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCC2 : MonoBehaviour
{
    private Animator animator;
    private CharacterController cc;

     private Vector3 playerVelocity;
    private bool isGrounded;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -20f;


    
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();       
         cc = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    bool old = true;
    void Update()
    { // 캐릭터가 지면에 있는 경우
         //  isGrounded 가 false 였다가 true 로 바뀌는 경우
         // 즉 이전이 공중이였고 이번에 ground면
        if ( old == false &&  cc.isGrounded  ) {
            animator.SetTrigger("doLand");            
            animator.SetBool("isJump", false);
        }
        old = cc.isGrounded;


        // 플레이어 점프
        if ( cc.isGrounded && Input.GetButtonDown("Jump"))
        {
                animator.SetTrigger("doJump");            
                animator.SetBool("isJump", true);
                playerVelocity.y =  6.0f;//Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        // 중력 적용
        playerVelocity.y += gravityValue * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
    }
}
