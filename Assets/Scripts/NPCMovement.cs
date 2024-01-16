using UnityEngine;
using System.Collections.Generic;
public class NPCMovement : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed as needed
    private Vector3 moveDirection;

    private bool collided = false;

    public bool orderFilled = false;

    private Guest guest;

    // private float targetRotation = 90f;
    private AudioSource audioSource;
    // private float currentRotation = 90f;

    void Start()
    {
        // Define initial direction or starting point if necessary
        moveDirection = Vector3.forward;
        // Guest.OnOrderFulfilled += HandleOrderFulfilled;
        guest = GetComponent<Guest>();
        ChecklistManager.OnPizzaDone += HandleOrderFulfilled;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Call a function to handle movement

        if (!collided) {
            Move();
        }

        else if (orderFilled) {
            if (transform.rotation.eulerAngles[1] < 180)
            {
                Rotate();
            } 
            else {
                Move();
            }
        }
    }



    void Move()
    {
        // Implement your movement logic here
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void HandleOrderFulfilled()
    {
        orderFilled = true;
        // Perform actions when an order is fulfilled
        Debug.Log("Order Fulfilled: " );
    }
    void Rotate()
    {
        // Implement your movement logic here
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)

    {
        // Check if the entering object has a specific tag
        if (other.CompareTag("StopMovingCollider"))
        {
            // Your code here, for example:
            Debug.Log("Triggered by object tagged 'StopMovingCollider'");

            // You can access the entering GameObject and do more actions
            // GameObject enteringObject = other.gameObject;
            collided = true;
            // Perform actions with the enteringObject
            guest.generateOrder();
            PlaySound();
        }
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }


    public void PlaySound()
    {
        // Check if the AudioSource and AudioClip are not null
        if (audioSource != null)
        {
            // Play the sound
            audioSource.Play();
        }
    }

}