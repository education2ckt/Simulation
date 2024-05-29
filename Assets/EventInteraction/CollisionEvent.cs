using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StringEvent : UnityEvent <string> {}
    
public class CollisionEvent : MonoBehaviour
{
    //public UnityEvent myEvent0;
    
    public StringEvent myEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) {
        //if ( myEvent0 != null ) myEvent0.Invoke();
        if ( myEvent != null ) myEvent.Invoke("hello");
    }
}
