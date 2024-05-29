using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EventCamera : MonoBehaviour
{

    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        StartCoroutine(Run());
    }

    void OnTriggerEnter(Collider collider) {
        StartCoroutine(Run());
    }

    IEnumerator Run() {

        print("start");

        // zoom 카메라 일 때 속도 처리필요

        GameObject old = (CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera as CinemachineVirtualCamera).gameObject;
        camera.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        camera.SetActive(false);
        old.SetActive(true);
        yield return null;
        print("end");

    }
}
