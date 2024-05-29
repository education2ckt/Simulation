using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character {
public class Generator : MonoBehaviour
{
     public Transform[] targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());   
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator Run()
    {        
        
        while ( true) {
            print("시작 1");
            StartCoroutine(MoveCoroutine("Assassin", targets[0].position, 2, 0.7f));
            StartCoroutine(MoveCoroutine("Assassin2", targets[1].position, 2, 0.7f));
               
            yield return new WaitForSeconds(3.0f);
            print("시작 2");
            StartCoroutine(MoveCoroutine("Assassin", targets[1].position, 2, 0.1f));
            StartCoroutine(MoveCoroutine("Assassin2", targets[0].position, 2, 0.1f));
            yield return new WaitForSeconds(3.0f);
        }
    }    
    IEnumerator MoveCoroutine(string name, Vector3 targetPos, float duration, float speed)
    {
        GameObject obj = GameObject.Find(name);

        //obj.GetComponent<RunDemoMain>().speed = speed;

        float elapsedTime = 0f;
        Vector3 startingPos = obj.transform.position;
        
        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / duration);
            obj.transform.forward = targetPos.normalized;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPos;
    }
}
}