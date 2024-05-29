using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBasic2 : MonoBehaviour
{
    public float jumpHeight = 2f; // 점프 높이 조절
    public float gravity = 9.8f;  // 중력 가속도

    private float verticalSpeed = 0f;
    private bool isJumping = false;
    private bool isGrounded = true;

    private float yy = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // 점프를 시작할 때
            isJumping = true;
            verticalSpeed = Mathf.Sqrt(2 * gravity * jumpHeight); // 초기 속도 계산
        }

        // 중력에 따라 아래로 이동
        verticalSpeed -= gravity * Time.deltaTime;
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);

        
        RaycastHit hit; // Raycast에 hit된 객체를 불러온다.        
        bool gg = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);        
        if ( gg ) {
            //충돌지점
            yy =  transform.position.y;        
            print("--------------    " + yy);

        }
        if ( yy !=-1 && transform.position.y < yy )
        {
            transform.position = new Vector3(transform.position.x, yy, transform.position.z);
            isJumping = false;
            verticalSpeed = 0f;
        }
        
    }

}
