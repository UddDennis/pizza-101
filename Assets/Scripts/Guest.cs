using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
[System.Serializable]
public class Guest : MonoBehaviour
{
    public Order order;
    public bool fulfilled = false;
    
    public delegate void OrderFulfilledEventHandler(Order order);

    // Define the event using the delegate
    public static event OrderFulfilledEventHandler OnOrderFulfilled;


    
    public delegate void OrderGeneratedEventHandler(Order order);

    // Define the event using the delegate
    public static event OrderGeneratedEventHandler OnOrderGenerated;



     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnOrderFulfilled?.Invoke(order);
        }
    }

    public void generateOrder() {
        

        List<Ingredient> myObjects = new List<Ingredient>
        {
            new Ingredient("tomato"),
            new Ingredient("cheese"),
            new Ingredient("banana"),
            // new Ingredient("Corn"),
            new Ingredient("mushroom")
        };

        System.Random random = new System.Random();
        int countToSelect = random.Next(2, 4);

        List<Ingredient> shuffledList = myObjects.OrderBy(x => random.Next()).ToList();
        List<Ingredient> selectedObjects = shuffledList.Take(countToSelect).ToList();

        order = new Order(selectedObjects);     

        // Debug.Log();
        foreach (Ingredient ing in selectedObjects)
        {
            Debug.Log(ing.name);
        }


        OnOrderGenerated?.Invoke(order);
    }
}