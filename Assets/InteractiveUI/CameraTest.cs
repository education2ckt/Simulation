using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] cameras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        // face zoom으로 이동하거나 face zoom에서 이동할때는 속도를 0으로 한다. 그래야 전환시 이상하지 않다.

        if ( Input.GetKeyDown(KeyCode.Alpha0)) {        
            CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = 2.0f;            
            for(int i = 0; i < cameras.Length; i++) cameras[i].SetActive(false);
            cameras[0].SetActive(true);                        
        }
        
        
        if ( Input.GetKeyDown(KeyCode.Alpha1)) {                    
            CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = 2.0f;
            for(int i = 0; i < cameras.Length; i++) cameras[i].SetActive(false);
            cameras[1].SetActive(true);            
        }
        if ( Input.GetKeyDown(KeyCode.Alpha2)) {            
            CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = 2.0f;
            for(int i = 0; i < cameras.Length; i++) cameras[i].SetActive(false);
            cameras[2].SetActive(true);            
        }
        if ( Input.GetKeyDown(KeyCode.Alpha3)) {   
            CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend.m_Time = 2.0f;
         
            for(int i = 0; i < cameras.Length; i++) cameras[i].SetActive(false);
            cameras[3].SetActive(true);            
        }
        
    }
}
