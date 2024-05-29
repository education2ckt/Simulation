using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    public ScenarioEngine engine;
    public string filename;
    void OnTriggerEnter(Collider other) 
    {        
        string script = Resources.Load<TextAsset>(filename).ToString();
        StartCoroutine(engine.PlayScript(script));        

    }
}
