using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public float timer;
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
        server = GameObject.Find("Server");
        manager = GameObject.Find("_manager");
        manager.GetComponent<queue>().line.Add(gameObject);
        patience = 100 + Random.Range(0, 11);
        serveTime = 100 + Random.Range(1, 11);
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
            manager.GetComponent<queue>().line.Remove(gameObject);
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
                manager.GetComponent<queue>().isServing = false;
                moveUp();
            }
        }

    }

    public void moveUp()
    {
        for(int i = 0;i > manager.GetComponent<queue>().line.Count;i++){
            manager.GetComponent<queue>().line[10] = manager.GetComponent<queue>().line[2+i];
            manager.GetComponent<queue>().line.RemoveAt(2+i);
            manager.GetComponent<queue>().line[1+i] = manager.GetComponent<queue>().line[10];
            manager.GetComponent<queue>().line.RemoveAt(10);
        }
        
    }
}
