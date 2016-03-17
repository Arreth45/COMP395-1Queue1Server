using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();

    public int served = 0;
    public int left = 0;
    public float uptime = 0;
    public float idletime = 0;
    public float servetime = 0;
    float upTimer, serveTimer, idleTimer = 0;

    public bool isServing = false;

    // Use this for initialization

    void Update()
    {
        if (!isServing && GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople > 0)
        {
            isServing = true;
            line.TrimExcess();
            line[0].GetComponent<person>().isBeingServed = true;
        }
    }
}