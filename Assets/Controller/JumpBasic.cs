using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBasic : MonoBehaviour
{

   public float jumpHeight = 3f; // 점프 높이 조절
    public float gravity = 9.8f;  // 중력 가속도

    private float verticalSpeed = 0f;
    private bool isJumping = false;

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

 
        // 점프 중인 동안은 계속해서 위로 이동합니다.
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            isJumping = false;
            verticalSpeed = 0f;
        }
    }
}