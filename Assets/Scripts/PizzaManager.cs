using UnityEngine;
using UnityEngine.UI;

public class PizzaManager : MonoBehaviour
{
    

    public GameObject pizzaToInstantiate;

    private GameObject currentPizza; 
    void Start()
    {
        Guest.OnOrderGenerated += MakePizza;
        ChecklistManager.OnPizzaDone += DeletePizza;
    }

    void MakePizza(Order order) 
    {
        GameObject pizza = Instantiate(pizzaToInstantiate);
        AddIngredient addingr = pizza.GetComponent<AddIngredient>();
        if (addingr != null)
        {
            addingr.CreateIngredientList(order);
        }
        currentPizza = pizza;
    }

    void DeletePizza() {
        Destroy(currentPizza);
    }
    
    void Update() 
    {
        {
            // OnPizzaDone?.Invoke(order);
        }
    }

}