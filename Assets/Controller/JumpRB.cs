    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRB : MonoBehaviour
{
    public float power = 5.0f;
    private Rigidbody rb = null;
    private Animator animator;
    private bool isJump = false;
    private bool isGrounded = true;
    // Start is called before the first frame update

    public LayerMask groundLayer;

    void Start()
    {
         rb = GetComponent<Rigidbody>();        
         animator = GetComponent<Animator>();
    }

    void Update()
    {        
        

        if ( Input.GetKeyDown(KeyCode.Space)   ) { 
            rb.AddForce(Vector3.up*power, ForceMode.Impulse);              
            animator.SetTrigger("doJump");            
            animator.SetBool("isJump", true);            
            isJump = true;
        }  
        
    }

    void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Floor") {
            print("landing");
            animator.SetTrigger("doLand");            
            animator.SetBool("isJump", false);
            isJump = false;
        }
    }

}
