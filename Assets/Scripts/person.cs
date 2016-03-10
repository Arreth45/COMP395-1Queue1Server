using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public int place;
    public float timer;
    public float serveTime;
    public float serverTimer;
    public bool isServed = false;
    int counter;
    int openSpace;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("_manager").GetComponent<queue>().line.Add(this.gameObject);
        //get positon of person in line
        
        patience = 10 + Random.Range(0, 11);
        serveTime = Random.Range(1, 11);
    }

    // Update is called once per frame
    void Update()
    {
        timer = +Time.deltaTime * 100;
        if (timer >= patience)
        {
            this.gameObject.GetComponent<person>().isServed = true;
            GameObject.Find("_manager").GetComponent<queue>().left++;
        }


        if (isServed)
        {
            GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople--;
            Destroy(gameObject);
        }
    }

    public void servePerson()
    {
        while (this.serverTimer < this.serveTime)
        {
            this.serverTimer += Time.deltaTime * 100;
            if (this.serverTimer > this.serveTime)
            {
                this.transform.Translate(1, 5, 0);
                GameObject.Find("_manager").GetComponent<queue>().served++;
                this.gameObject.GetComponent<person>().isServed = true;
                GameObject.Find("_manager").GetComponent<queue>().isServing = false;
            }
        }

    }
}
