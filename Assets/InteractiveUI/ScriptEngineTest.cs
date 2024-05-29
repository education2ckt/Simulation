using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEngineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          string[] scripts = {
            "camera(CM vcam4)",
            "camera(0);camera(CM vcam3);wait(3);camera(2);camera();wait(3);dialog(char1,안녕하세요,3);dialog(char2,누구신가요?,3);dialog(char3,난이순신. 하하하,-1);dialog()",            
            "video(play, video1);wait(5);video(stop)",
            "info(char1,안녕또볼까?\n아니요....\n......, -1)",
            "image(background,[배경]안녕,fill,3);image(background2,[player]누구?,fade,3);image(background3,[배경]시스템이야,fill,3);image(hide)" 
            };
        if ( Input.GetKeyDown(KeyCode.Alpha1)) StartCoroutine( ScriptEngine.engine.executeScript(scripts[4]));
      
    }
}
