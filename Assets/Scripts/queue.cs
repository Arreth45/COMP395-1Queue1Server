using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();
    int counter;
    int openSpace;
    public double served;
    public float uptime;
    public float idletime;
    public float servetime;
    float upTimer, serveTimer, idleTimer;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        upTimer += Time.deltaTime;
        idleTimer += Time.deltaTime;
        uptime += upTimer;
        idletime += idleTimer;
        servePerson(line[0]);
    }

    private void MoveUp()
    {
        for (int i = 0; i > (line.Count - counter); i++)
        {
            line[openSpace] = line[openSpace + 1];
            openSpace++;
        }
    }

    public void LeaveLine(GameObject person)
    {
        openSpace = line.IndexOf(person);
        line.Remove(person);
        person.transform.Translate(10, 10, 0);
        MoveUp();
    }

    public void servePerson(GameObject person)
    {
        serveTimer += Time.deltaTime;
        servetime += serveTimer;
        if (serveTimer >= person.GetComponent<person>().serveTime)
        {
            served++;
            GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople--;
            LeaveLine(person);
        }
    }
}