using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character {
public class ToTarget : MonoBehaviour
{
    public Transform[] targets;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.Alpha1)) {
            GameObject obj = GameObject.Find("Assassin");
            //obj.GetComponent<RunDemoMain>().speed = 0.2f;
            StartCoroutine(MoveCoroutine(obj, targets[0].position, 4));
        }

         if ( Input.GetKey(KeyCode.Alpha2)) {
            GameObject obj = GameObject.Find("Assassin");
            //obj.GetComponent<RunDemoMain>().speed = 0.7f;
            StartCoroutine(MoveCoroutine(obj, targets[1].position, 2));
        }
    }

    IEnumerator MoveCoroutine(GameObject gameObject, Vector3 targetPos, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPos = gameObject.transform.position;
        
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / duration);
            transform.forward = targetPos.normalized;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }
}
}
