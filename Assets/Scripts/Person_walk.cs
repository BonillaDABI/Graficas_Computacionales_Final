using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 3.0f; // The speed at which the character moves
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the horizontal and vertical input (WASD or arrow keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

        // Create a new vector to store the direction of movement
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // If there's some input (i.e., if the player is pressing a key)
        if (movement != Vector3.zero)
        {
            // Set the isWalking parameter to true
            animator.SetBool("isWalking", true);

            // Rotate the character in the direction of movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

            // Move the character
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else
        {
            // If there's no input (i.e., if the player isn't pressing any keys)
            // Set the isWalking parameter to false
            animator.SetBool("isWalking", false);
        }
    }
}
