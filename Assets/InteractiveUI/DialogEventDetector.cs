using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEventDetector : MonoBehaviour
{
    public string[] script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void OnMouseDown(){
        StartCoroutine(DialogTest.dt.ShowDialog3(script));
    }


    void OnTriggerEnter(Collider collider) {
        StartCoroutine(DialogTest.dt.ShowDialog3(script));
    }


}
