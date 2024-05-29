using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    // Start is called before the first frame update


       public Transform targetPosition; // The target position where you want the object to move
    public float height = 5f; // The height of the parabolic trajectory
    public float speed = 5f; // The speed of the movement

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the object.");
        }
    }

    void FixedUpdate()
    {
        
         float step = speed * Time.deltaTime;

        // 목표 지점까지의 거리를 계산
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition.position);

        // 거리가 일정 이상 남았을 때만 포물선 운동 계산
        if (distanceToTarget > 0.0f)
        {
            // 포물선 운동 계산
            float t = Time.time;
            float x = Mathf.Lerp(transform.position.x, targetPosition.position.x, step);
            float y = height * Mathf.Sin((t * speed) / 2f);
            float z = Mathf.Lerp(transform.position.z, targetPosition.position.z, step);

            // 새로운 위치로 이동
            Vector3 newPosition = new Vector3(x, y, z);
            rigidbody.MovePosition(newPosition);
        }
    }    
}