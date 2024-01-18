﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust this value in the Inspector to change player speed

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
}
