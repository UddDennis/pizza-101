using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Define a delegate
    // public delegate void OrderFulfilledEventHandler(Order order);
    public GameObject guestToSpawn;

    List<GameObject> currentGuests = new List<GameObject>();
    // // Define the event using the delegate
    // public static event OrderFulfilledEventHandler OnOrderFulfilled;

    public int points = 0;
    private Guest currentGuest;

    private GameObject currentPizza;
    void Start()
    {
        ChecklistManager.OnPizzaDone += SpawnGuest;
        ChecklistManager.OnPizzaDone += AddPoints;
    }
    void Update()
    {
        if (currentGuests.Count < 1) 
        {
            SpawnGuest();
        }
    }

    void AddPoints() 
    {
        points += 1;
    }

    void SpawnGuest() 
    {
        GameObject spawnedObject = Instantiate(guestToSpawn);
        currentGuests.Add(spawnedObject);
        currentGuest = spawnedObject.GetComponent<Guest>();
    }

}