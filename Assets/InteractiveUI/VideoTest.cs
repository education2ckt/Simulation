using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    private VideoPlayer player ;
     void Start()
    {
        player = GetComponent<VideoPlayer>();

        player.Play();
    }  
    
}
