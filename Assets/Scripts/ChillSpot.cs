using UnityEngine;

public class ChillSpot : MonoBehaviour
{
    private float time = 2f;
    private int maxPeople = 10;
    public int currentPeople;
    public GameObject Person;
    // Use this for initialization
    void Start()
    {
        AddPeople();
    }

    // Update is called once per frame
    void Update()
    {
        AddPeople();
    }

    void AddPeople()
    {
        if (currentPeople < maxPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 5), Random.Range(0, -5)), Quaternion.identity);
            GameObject.Find("_manager").GetComponent<queue>().line.Add(Person);
            currentPeople++;
        }
    }

}
