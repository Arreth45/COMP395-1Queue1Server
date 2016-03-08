using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public int place;
    public float timer;
    public float serveTime;
    public bool isServed = false;

    // Use this for initialization
    void Start()
    {
        patience = 10 + Random.Range(0, 11);
        serveTime = Random.Range(1, 11);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (timer >= patience)
        {
            GameObject.Find("_manager").GetComponent<queue>().LeaveLine(this.GetComponent<GameObject>());
        }
        */

        if (isServed)
        {
            Destroy(gameObject);
            GameObject.Find("_manager").GetComponent<ChillSpot>().currentPeople--;
        }
    }
}
