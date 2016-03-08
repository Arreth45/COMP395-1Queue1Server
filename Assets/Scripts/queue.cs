using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();

    public double served = 0;
    public float uptime = 0;
    public float idletime = 0;
    public float servetime = 0;
    float upTimer, serveTimer, idleTimer = 0;

    public bool isServing = false;

    // Use this for initialization

    void Update()
    {
        if (!isServing)
        {
            line[0 + (int)served].GetComponent<person>().servePerson();
        }
    }
}