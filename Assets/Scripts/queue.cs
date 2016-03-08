using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();
    int counter;
    int openSpace;
    public double served = 0;
    public float uptime = 0;
    public float idletime = 0;
    public float servetime = 0;
    float upTimer, serveTimer, idleTimer = 0;

    private bool isServing = false;

    // Use this for initialization

    void Update()
    {
        if (GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople > 0 && !isServing)
        {
            /*
            servePerson(line[0]);
            */
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
        //MoveUp();
    }

    public void servePerson(GameObject person)
    {
        isServing = true;
        serveTimer += 0.0001f;
        servetime += 0.0001f;
        if (servetime > person.GetComponent<person>().serveTime)
        {

            person.transform.Translate(1, 5, 0);
            served++;
            LeaveLine(person);
            person.GetComponent<person>().isServed = true;
            isServing = false;
        }

    }
}