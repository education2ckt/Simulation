using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointAgent : MonoBehaviour
{
    public enum  LoopMode {None, Loop, Reverse};
    public LoopMode mode;
     public GameObject  path;
    private int destPoint = 0;
    private NavMeshAgent agent;
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }
    int dir = 1;
    void GotoNextPoint() {        

        agent.destination = path.transform.GetChild(destPoint %path.transform.childCount).transform.position;

        if ( mode == LoopMode.None) {
             if ( destPoint < path.transform.childCount - 1) destPoint++;
        } else if ( mode ==  LoopMode.Loop ) {
            destPoint++;
        } else if ( mode ==  LoopMode.Reverse) {
            if (destPoint == 0 )  dir = 1;
            else if (destPoint == path.transform.childCount -1 )  dir = -1;
            destPoint += dir;            
        }        
    }
    void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
