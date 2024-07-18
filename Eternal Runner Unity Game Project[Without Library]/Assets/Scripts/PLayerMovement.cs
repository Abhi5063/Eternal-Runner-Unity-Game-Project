using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Movement speed
    public float rotationSpeed = 720f; // Rotation speed
    public float gravity = -9.81f; // Normal gravity

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    void Start()
    {
        // Initialize the CharacterController component
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        if (!Restart.gameOver) // Check gameOver state from Restart class
        {
            // Get player input
            float horizontalInput = 0;

            // Remap keys: A -> Backward, D -> Forward
            if (Input.GetKey(KeyCode.A))
            {
                horizontalInput = -1; // Move backward
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontalInput = 1; // Move forward
            }

            // Automatically move left
            float autoMoveSpeed = speed; // Adjust this speed as needed
            Vector3 automaticMovement = new Vector3(-1, 0, 0) * autoMoveSpeed;

            // Determine movement direction and magnitude
            Vector3 movementDirection = new Vector3(0, 0, horizontalInput); // Move along the z-axis
            float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
            movementDirection.Normalize();

            // Apply gravity
            ySpeed += gravity * Time.deltaTime;

            // Check if the player is grounded
            if (characterController.isGrounded)
            {
                ySpeed = -0.5f; // Small negative value to stick to the ground
            }

            // Calculate velocity
            Vector3 velocity = (movementDirection * magnitude) + automaticMovement;
            velocity.y = ySpeed;

            // Move the character
            characterController.Move(velocity * Time.deltaTime);

            // Handle rotation
            if (movementDirection != Vector3.zero || automaticMovement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(automaticMovement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obsticle"))
        {
            Restart.TriggerGameOver();
        }
    }
}
