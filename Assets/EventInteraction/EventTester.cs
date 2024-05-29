using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detection1(string tag) {
        Utils.Log("검출됨~~~~~ : " + tag);
        //DialogSystem.ds.Show("누구신가요??");
        //DialogSystem.ds.Show( new [] {"누구신가요??", "그러게요"});

        DialogSystem.ds.ShowImage();



    }
}
