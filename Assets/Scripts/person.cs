using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public float timer;
    public double priority;
    public float serveTime;
    public float serverTimer;
    public bool isServed = false;
    public GameObject server;
    public GameObject manager;

    public float speed = 1;

    public bool isBeingServed = false;
    int counter;
    int openSpace;

    // Use this for initialization
    void Start()
    {
        //initialization of Variables
        server = GameObject.Find("Server1");
        manager = GameObject.Find("_manager");
        patience = 100 + Random.Range(0, 11);
        serveTime = 100 + Random.Range(1, 11);
        priority = Random.Range(0, 6);

        //add person to line
        manager.GetComponent<queue>().line1.Add(gameObject);

        //cut line at max priority
        if (priority == 5)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            cutLine();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = +Time.deltaTime * 100;
        if (timer >= patience)
        {
            gameObject.GetComponent<person>().isServed = true;
            manager.GetComponent<queue>().left++;
        }

        if (isServed)
        {
            manager.GetComponent<ChillSpot>().currentPeople--;
            manager.GetComponent<queue>().line1.Remove(gameObject);
            Destroy(gameObject);
        }

        if (isBeingServed)
        {
            serverTimer += Time.deltaTime * 100;
            float step = speed;
            transform.position = Vector3.MoveTowards(transform.position, server.transform.position, step);
            if (serverTimer > serveTime)
            {
                manager.GetComponent<queue>().served++;
                gameObject.GetComponent<person>().isServed = true;
                moveUp();
            }
        }
    }

    public void moveUp()
    {
        for (int i = 0; i > manager.GetComponent<queue>().line1.Count; i++)
        {
            manager.GetComponent<queue>().line1[10] = manager.GetComponent<queue>().line1[2 + i];
            manager.GetComponent<queue>().line1.RemoveAt(2 + i);
            manager.GetComponent<queue>().line1[1 + i] = manager.GetComponent<queue>().line1[10];
            manager.GetComponent<queue>().line1.RemoveAt(10);
        }
    }

    //high priority cutLine
    public void cutLine()
    {
        //stop person at front
        manager.GetComponent<queue>().line1[0].GetComponent<person>().isBeingServed = false;
        //move person at front to the side
        manager.GetComponent<queue>().line1[0].GetComponent<person>().gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2, 3.5f, 0), speed);
        isBeingServed = true;
    }
}
