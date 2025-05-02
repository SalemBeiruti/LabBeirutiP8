using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 7f;
    private Rigidbody playerRb;
    private bool isGrounded;

    void Start()
    {
        //this is to prevent drags and friction to keep movement constant and smooth
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;

        playerRb.drag = 0;
        playerRb.angularDrag = 0;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = playerRb.velocity;
        velocity.x = horizontalInput * speed;
        playerRb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);

        // jump only when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = new Vector3(velocity.x, jumpForce, velocity.z);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}