using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;


public class ChecklistManager : MonoBehaviour
{
    // Reference to the checklist row prefab
    public GameObject checklistRowPrefab;

    // List of ingredients the guest wants
    private List<string> ingredients;

    // // Dictionary to store toggle references for each ingredient
    // private Dictionary<string, Toggle> ingredientToggles = new Dictionary<string, Toggle>();
    private List<Toggle> toggleList= new List<Toggle>();

    public delegate void PizzaDoneEventHandler();

    // Define the event using the delegate
    public static event PizzaDoneEventHandler OnPizzaDone;

    void Start()
    {
        Guest.OnOrderGenerated += MakeChecklist;
        AddIngredient.OnIngredientAdded += CheckItem;
    }

    void CheckItem(string name)
    {
        toggleList[ingredients.IndexOf(name)].isOn = true;
        
        if (toggleList.All(x => x.isOn))
        {
            Debug.Log("Pixxa sdone");
            OnPizzaDone?.Invoke();
            RemoveAllChildren();
        }
    }


    void MakeChecklist(Order order) 
    {
        foreach (Ingredient ingredient in order.ingredients)
        {
            GameObject checklistRow = Instantiate(checklistRowPrefab, transform);
            TextMeshProUGUI labelText = checklistRow.transform.Find("Label").GetComponent<TextMeshProUGUI>();
            labelText.text = ingredient.name;

            // Get the Toggle component and store the reference in the dictionary
            Toggle toggle = checklistRow.transform.Find("Toggle").GetComponent<Toggle>();
            // ingredientToggles.Add(ingredient, toggle);
            ingredients = order.ingredients.Select(x => x.name).ToList();
            toggleList.Add(toggle);
        }
    }

    void RemoveAllChildren()
    {
        // Iterate through all child objects and destroy them
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Optionally, clear the children list after destroying them
        transform.DetachChildren();
        toggleList.Clear();
    }
}
