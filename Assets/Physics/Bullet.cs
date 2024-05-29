using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    void OnCollisionEnter(Collision collision) 
    {        
        Utils.Log("물리 충돌함 " + collision.gameObject.name);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) 
    {
        Utils.Log("충돌함 " + other.gameObject.name);
        Destroy(gameObject);
    }
}
