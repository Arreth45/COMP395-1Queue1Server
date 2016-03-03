using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();
    int counter;
    int openSpace;
    double served;
    float uptime;
    float idletime;
    float servetime;
    float upTimer, serveTimer, idleTimer;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            line.Add(GameObject.FindGameObjectWithTag("person"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        upTimer += Time.deltaTime;
        idleTimer += Time.deltaTime;
        uptime += upTimer;
        idletime += idleTimer;
        servePerson(line[0]);
        if (line.Count < 10)
        {
            for (int i = 0; i > (10 - line.Count); i++)
            {
                line.Add(GameObject.FindGameObjectWithTag("person"));
            }
        }
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
        Destroy(person);
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
