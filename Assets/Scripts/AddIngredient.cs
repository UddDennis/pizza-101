using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AddIngredient : MonoBehaviour
{
    private List<string> ingredients;
    private Ingredient test;

    public delegate void IngredientAddedEventHandler(string ingredient);

    // Define the event using the delegate
    public static event IngredientAddedEventHandler OnIngredientAdded;
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            foreach (string ingr in ingredients)
            {
                if (collision.gameObject.tag == ingr)
                {
                        OnIngredientAdded?.Invoke(ingr);
                }
            }
        }        
    }

    public void CreateIngredientList(Order order)
    {
        ingredients = order.ingredients.Select(x => x.name).ToList();
        Debug.Log("works");
    }

}