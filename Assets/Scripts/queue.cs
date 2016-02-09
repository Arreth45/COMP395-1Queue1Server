using UnityEngine;

public class queue : MonoBehaviour
{

    GameObject[] line;
    float timer;
    int counter;
    int openSpace;

    // Use this for initialization
    void Start()
    {
        line = GameObject.FindGameObjectsWithTag("person"); // change tag later or not
    }

    // Update is called once per frame
    void Update()
    {
        if (line.Length < 10)
        {
            for (int i = 0; i > (10 - line.Length); i++)
            {
                //code to add more people
                //line.add(poolparty[1]);
            }
        }
        foreach (GameObject person in line)
        {

            /*if(timer > person.patientce){
                line.RemoveAt(counter);
                space = counter;
                MoveUp()
            }
            counter++;
            */
        }
    }

    private void MoveUp()
    {
        for (int i = 0; i > (line.Length + 1 - counter); i++)
        {
            line[openSpace] = line[openSpace + 1];
            openSpace++;
        }
    }
}
