using UnityEngine;

public class person : MonoBehaviour
{
    public float patience;
    public int place;
    public float timer;

    // Use this for initialization
    void Start()
    {
        patience = 10 + Random.Range(0, 11);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= patience)
        {
            gameObject.GetComponent<queue>().LeaveLine(gameObject);
        }

    }
}
