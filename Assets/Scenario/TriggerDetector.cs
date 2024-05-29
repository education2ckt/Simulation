using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public ScenarioEngine engine;
    
     void OnTriggerEnter(Collider other) 
    {
        string script = Resources.Load<TextAsset>("gamescript1").ToString();
        StartCoroutine(engine.PlayScript(script));        
    }

}
