using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 respawnPosition;
    private Rigidbody rb; // Rigidbody reference for resetting velocity
    private float initialSpeed;
    private float currentSpeed;

    public float speed = 5f; // Default speed value

    void Start()
    {
        // Set the initial respawn position
        respawnPosition = transform.position;
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        initialSpeed = speed; // Store the initial speed value
        currentSpeed = speed; // Set the current speed value to the initial speed value
    }

    void Update()
    {
        // Check if "R" key is pressed
        if (Input.GetKey(KeyCode.R))
        {
            // Reset player position and movement
            Respawn();
        }

        // Handle player movement using the current speed value
        // Example: You can add your movement controls here
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            // Update the respawn position when a checkpoint is reached
            respawnPosition = other.transform.position;
        }
        else if (other.CompareTag("Lava"))
        {
            // Respawn at the last checkpoint when player touches the lava
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reset player position to the last checkpoint
        transform.position = respawnPosition;

        // Reset player's velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Reset player's speed value to the initial speed value
        speed = initialSpeed;
    }
}