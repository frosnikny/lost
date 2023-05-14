using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    // Define movement directions
    private Vector2[] directions = new Vector2[]
    {
        new Vector2(1, 0),      // Right
        new Vector2(1, 1),      // Up-Right
        new Vector2(0, 1),      // Up
        new Vector2(-1, 1),     // Up-Left
        new Vector2(-1, 0),     // Left
        new Vector2(-1, -1),    // Down-Left
        new Vector2(0, -1),     // Down
        new Vector2(1, -1)      // Down-Right
    };

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Get input for horizontal and vertical axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize vector to prevent faster diagonal movement
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Find the closest direction to the movement vector
        int closestDirectionIndex = 0;
        float closestDirectionDistance = Mathf.Infinity;
        for (int i = 0; i < directions.Length; i++)
        {
            float directionDistance = Vector2.Distance(movement, directions[i]);
            if (directionDistance < closestDirectionDistance)
            {
                closestDirectionIndex = i;
                closestDirectionDistance = directionDistance;
            }
        }

        // Move player in the closest direction
        transform.position += (Vector3)directions[closestDirectionIndex] * moveSpeed * Time.deltaTime;

        // Check for jump input and apply force
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}