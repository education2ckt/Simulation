using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Transform pos;
    public GameObject prefab;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");
        transform.Rotate (-y* Time.deltaTime * 60, x * Time.deltaTime * 60,0);
        if  (Input.GetKeyDown(KeyCode.Space) ) {
            GameObject bullet = Instantiate(prefab, pos.position, Quaternion.identity);  
            bullet.GetComponent<Rigidbody> ().AddForce (transform.forward   * 500);
            Destroy(bullet, 3);
        }        
    }
}
