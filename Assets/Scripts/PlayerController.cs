﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private int score = 0;
    public int health = 5;

    // Add two public variables to store references to the teleporter planes
    public GameObject teleporterPlane1;
    public GameObject teleporterPlane2;

    void Start()
    {
        // Initialization code if needed
    }

    void FixedUpdate()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the player
        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement)
    {
        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the player on the X and Z axes only
        Vector3 newPosition = transform.position + movement * speed * Time.fixedDeltaTime;
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Increment score when the Player touches an object tagged Pickup
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            // Decrement health when the Player touches an object tagged Trap
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }

        // Check if the player touches teleporterPlane1
        if (other.gameObject == teleporterPlane1)
        {
            TeleportPlayer(teleporterPlane2);
        }

        // Check if the player touches teleporterPlane2
        if (other.gameObject == teleporterPlane2)
        {
            TeleportPlayer(teleporterPlane1);
        }
    }

    void TeleportPlayer(GameObject targetTeleporter)
    {
        // Teleport the player to the position of the targetTeleporter
        transform.position = targetTeleporter.transform.position;
    }
}
