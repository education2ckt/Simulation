using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPos;
    public GameObject bullet;
    // Start is called before the first frame update
         private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0)) {
        GameObject obj = Instantiate(bullet, attackPos.position, attackPos.rotation);
        obj.GetComponent<Rigidbody>().velocity = attackPos.transform.forward * 30;
        Destroy(obj, 2.0f);
        }
    }
}
