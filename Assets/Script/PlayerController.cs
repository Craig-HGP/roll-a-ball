using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    public float speed = 0;

    
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent <Rigidbody>(); 
    }

    // This function is called when a move input is detected.
    void OnMove (InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate() 
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed); 

    }

    void OnTriggerEnter(Collider other) 
    {
        other.gameObject.SetActive(false);

        if (other.gameObject.CompareTag("PickUp")) 
        {
            // Check if the object the player collided with has the "PickUp" tag.
            if (other.gameObject.CompareTag("PickUp")) 
            {
                // Deactivate the collided object (making it disappear).
                other.gameObject.SetActive(false);
            }
        }

    }

}
