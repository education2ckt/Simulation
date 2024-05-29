using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform pos;
    public GameObject prefab;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                ActFire(hit.point, 200);
                ActFireLinear(hit.point, 10);
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
