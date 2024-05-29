using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;

    void Update()
    {
        // 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
