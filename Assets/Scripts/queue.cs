﻿using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line1 = new List<GameObject>();
    public List<GameObject> line2= new List<GameObject>();
    public List<GameObject> line3 = new List<GameObject>();

    public int served = 0;
    public int left = 0;
    public float uptime = 0;
    public float idletime = 0;
    public float servetime = 0;
    float upTimer, serveTimer, idleTimer = 0;
  
    public double amountOfLines = 1;
    
    public GameObject Server1,Server2,Server3;

    // Use this for initialization

    void Update()
    {
        Server1 = GameObject.Find("Server1Actual");
        Server2 = GameObject.Find("Server2Actual");
        Server3 = GameObject.Find("Server3Actual");
        
        if (!Server1.GetComponent<server>().isServeing && GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople > 0)
        {
            Server1.GetComponent<server>().isServeing = true;
            line1.TrimExcess();
            line2.TrimExcess();
            line3.TrimExcess();
            line1[0].GetComponent<person>().isBeingServed = true;
        }
    }
}