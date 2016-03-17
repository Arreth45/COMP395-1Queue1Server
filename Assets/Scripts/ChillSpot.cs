﻿using UnityEngine;

public class ChillSpot : MonoBehaviour
{
    private int maxPeople = 10;
    public int currentPeople = 0;
    public GameObject Person;

    public float spawnTime;
    public float spawnTimer;

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
        if (maxPeople < currentPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 5), Random.Range(0, -5)), Quaternion.identity);
            currentPeople++;
        }
    }

}