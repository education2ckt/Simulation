using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce2 : MonoBehaviour
{

    public Transform pos;
    public GameObject prefab;

    public float shootingForce = 10f;  // 총알 발사 속도
    public float shootingAngle = 120;  // 발사 각도
    public float moveSpeed = 5f;        // 이동 속도

    private Vector3 direction;

    
    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(0))  // 마우스 왼쪽 버튼이 클릭되었을 때
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray2 = Camera.main.ScreenPointToRay(screenCenter);            

            RaycastHit hit;
            if (Physics.Raycast(ray2, out hit)) {
                //ActFire(hit.point, 200);
                //ActFireLinear(hit.point, 10);
                StartCoroutine(ActFireProjectile(hit.point, 45));
                
        }
    }
}

    void ActFire(Vector3 target, float weight ) {
        GameObject bullet = Instantiate(prefab, pos.position, pos.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.useGravity = true;    

        Vector3 dir = (target - bullet.transform.position).normalized;
        bulletRigidbody.AddForce( dir * weight);
    }


    void ActFireLinear(Vector3 target, float weight ) {
        GameObject bullet = Instantiate(prefab, pos.position, pos.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.useGravity = false; // 충돌후 제거되지 않으면 충돌후 우주에서 처럼 총알이 떠다님    
        Vector3 dir = (target - bullet.transform.position).normalized;
        bulletRigidbody.velocity = dir * weight;
    }

    void ActFire0(Vector3 target, float weight ) {
        float launchAngle = 45f;
        GameObject bullet = Instantiate(prefab, pos.position, pos.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = false; 

        Vector3 targetDirection = target - bullet.transform.position;
        float radianAngle = launchAngle * Mathf.Deg2Rad;

        // 목표 지점까지의 수평 거리 계산
        float horizontalDistance = new Vector3(targetDirection.x, 0, targetDirection.z).magnitude;

        // 수직 방향에서 목표 지점까지 도달하기 위한 초기 속도 계산
        float verticalVelocity = Mathf.Sqrt((horizontalDistance * Mathf.Abs(Physics.gravity.y)) / (Mathf.Sin(2 * radianAngle)));

        // 초기 속도 벡터 계산
        Vector3 launchVelocity = new Vector3(targetDirection.x, verticalVelocity * Mathf.Sign(Physics.gravity.y), targetDirection.z).normalized;

        // 힘을 가해 포물선 운동 시작
        rb.velocity = launchVelocity * horizontalDistance / Mathf.Cos(radianAngle);
    

        
    }

    IEnumerator ActFireProjectile(Vector3 target, float angle)
    {
        float gravity = 9.8f;
        GameObject bullet = Instantiate(prefab, pos.position, pos.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();        
        bulletRigidbody.useGravity = false;                
        
        float target_Distance = Vector3.Distance(bullet.transform.position, target);    
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / gravity);
        
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(angle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(angle * Mathf.Deg2Rad);
    
        float flightDuration = target_Distance / Vx;
    
        bullet.transform.rotation = Quaternion.LookRotation(target - bullet.transform.position);
        
        float elapse_time = 0;    
        float speed = 1.0f;
        while (elapse_time < flightDuration)
        {
                bullet.transform.Translate(0, 
                (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime * speed);           
                elapse_time += Time.deltaTime * speed; 
                yield return null;
        }           
        bulletRigidbody.useGravity = true;        
    }      
}
