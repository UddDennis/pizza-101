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
            new Ingredient("Tomato"),
            new Ingredient("Cheese"),
            new Ingredient("Banana"),
            new Ingredient("Corn"),
            new Ingredient("Mushroom")
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

    }
}