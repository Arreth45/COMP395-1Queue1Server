using UnityEngine;

public class ChillSpot : MonoBehaviour
{
    private double maxPeople;
    public int currentPeople = 0;
    public GameObject Person;

    // Use this for initialization
    void Start()
    {
        maxPeople = 10 * GameObject.Find("_manager").GetComponent<queue>().amountOfLines;
        AddPeople();
    }

    // Update is called once per frame
    void Update()
    {
        maxPeople = 10 * GameObject.Find("_manager").GetComponent<queue>().amountOfLines;
        AddPeople();
    }

    void AddPeople()
    {
        if (currentPeople < maxPeople )
        {
            Instantiate(Person, new Vector2(Random.Range(0, 5), Random.Range(0, -5)), Quaternion.identity);
            currentPeople++;
        }
    }

}