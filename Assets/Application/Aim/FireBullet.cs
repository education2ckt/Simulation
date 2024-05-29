using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace AimDemo {
public class FireBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spot;
    public CinemachineVirtualCamera vc;
    public Image cross;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Alpha1)  ) {
            vc.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 5.0f;
            cross.enabled = false;
        } 
        if ( Input.GetKeyDown(KeyCode.Alpha2)  ) {
            vc.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 1.5f;            
            cross.enabled = true;
        } 

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                ActFireLinear(hit.point, 30);                            
            }
        }                
    }

    void ActFireLinear(Vector3 target, float weight ) {
        GameObject bullet = Instantiate(bulletPrefab, spot.position, spot.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        Vector3 dir = (target - bullet.transform.position).normalized;
        bulletRigidbody.velocity = dir * weight;
    }
}
}