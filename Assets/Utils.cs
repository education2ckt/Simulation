using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static string message = "";

    public static void Log(string log) {
        message += log+"\n";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()    {
        if ( Input.GetKeyDown(KeyCode.Escape) ) message = "";        
    }

    void OnGUI() {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 15;
        guiStyle.normal.textColor = Color.red;        
        GUI.Label(new Rect(10,10, 100,100), message, guiStyle);
    }
    
}
