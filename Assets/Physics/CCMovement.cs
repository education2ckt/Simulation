using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CCMovement : MonoBehaviour   
{
    Vector3 dir; 

   CharacterController cc;
   public float speed;   

   // Start is called before the first frame update
   void Start()
   {
      cc = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   void Update()
   {
      if (cc.isGrounded)
      {         
         var h = Input.GetAxis("Horizontal");
         var v = Input.GetAxis("Vertical");

         dir = new Vector3(h, 0, v) * speed;

         if (dir != Vector3.zero)
         {
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(h, v) * Mathf.Rad2Deg, 0);
         }
         if (Input.GetKeyDown(KeyCode.Space))
            dir.y += 5.5f;
      }

      dir.y += -20 * Time.deltaTime;
      cc.Move(dir * Time.deltaTime);
   }
}