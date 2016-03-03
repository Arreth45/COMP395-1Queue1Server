using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public int place;
    public float timer;
    public float serveTime;
    public double id;

    // Use this for initialization
    void Start()
    {
        patience = 10 + Random.Range(0, 11);
        serveTime = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= patience)
        {
            GameObject.Find("_manager").GetComponent<queue>().servePerson(gameObject);
        }
    }
}
