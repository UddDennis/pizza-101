using UnityEngine;
using System.Collections.Generic;

public class DragIngredient : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public GameObject ingredientPrefab;

    private GameObject instantiatedIngredient;


    private List<GameObject> listOfItemsToDestroy = new List<GameObject>();

    void Start() 
    {
        
        ChecklistManager.OnPizzaDone += DeleteIngredients;
    }
    void OnMouseDown()
    {
        // Debug.Log("Mouse douwn");
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        SpawnIngredient(newPosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition();//+ offset*2;
            // transform.position = newPosition;

            // Spawn a tomato slice at the jar's position
            // SpawnIngredient(newPosition);

            instantiatedIngredient.transform.position = newPosition;
        }
    }

    void SpawnIngredient(Vector3 position)
    {
        // Instantiate a new tomato slice prefab
        GameObject ingr = Instantiate(ingredientPrefab, position, Quaternion.identity);
        instantiatedIngredient = ingr;
        listOfItemsToDestroy.Add(ingr);
        // Set any additional properties or behaviors for the tomato slice
        // (e.g., attaching a script to handle its own drag logic)

        // Destroy the tomato slice after a certain time if needed
        // Destroy(ingr, 5f);
    }

    void DeleteIngredients()
    {
        foreach (GameObject obj in listOfItemsToDestroy)
        {
            Destroy(obj);
        }

        // Clear the list after destroying all objects (optional)
        listOfItemsToDestroy.Clear();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z/2;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mousePosition.z = -Camera.main.transform.position.z;
        // // mousePosition.z = 0; // Ensure the ingredient is on the same z-plane as the jar

        // // Set the ingredient's position directly without considering the offset
        // return mousePosition;
    }
}
