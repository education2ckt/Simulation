using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTEst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) ) {
            Utils.Log("1111111111111111111111111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) )
            Utils.Log("222222222222222222");        
    }
}
