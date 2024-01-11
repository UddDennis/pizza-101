using UnityEngine;

public class JarInteraction : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public GameObject tomatoSlicePrefab;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;

            // Spawn a tomato slice at the jar's position
            SpawnTomatoSlice(newPosition);
        }
    }

    void SpawnTomatoSlice(Vector3 position)
    {
        // Instantiate a new tomato slice prefab
        GameObject tomatoSlice = Instantiate(tomatoSlicePrefab, position, Quaternion.identity);

        // Set any additional properties or behaviors for the tomato slice
        // (e.g., attaching a script to handle its own drag logic)

        // Destroy the tomato slice after a certain time if needed
        Destroy(tomatoSlice, 5f);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}