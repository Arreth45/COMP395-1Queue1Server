using UnityEngine;
using System.Collections.Generic;

public class ChillSpot : MonoBehaviour
{
    private float time = 2f;
    private int maxPeople = 10;
    public int currentPeople;
    public GameObject Person;
    private List<GameObject> poolParty = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        AddPeople();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyPerson();
        AddPeople();
    }

    void DestroyPerson()
    {
        // they "Leave" the pool to go to the line every 2f 
        //instead of death this is where one would put the code to move a selected object 
        //also if there is a better way to Find the Clone object that be cool too :D
        Destroy(GameObject.Find("Peep 1(Clone)"), time);
    }

    void AddPeople()
    {
        if(currentPeople < maxPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 5), Random.Range(0, -5)), Quaternion.identity);
            poolParty.Add(Person);
            Debug.Log("persons added");
            Debug.Log("Time Started");
            currentPeople++;
        }
    }

}
