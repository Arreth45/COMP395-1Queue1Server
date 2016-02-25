using UnityEngine;
using System.Collections.Generic;

public class queue : MonoBehaviour
{
    public List<GameObject> line = new List<GameObject>();
    int counter;
    int openSpace;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i > 10; i++)
        {
            line.Add(GameObject.FindGameObjectWithTag("person"));
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        line.Remove(person);
    }
}
