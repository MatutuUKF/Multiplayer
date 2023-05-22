using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;

    private Rigidbody rb;
    private bool isGrounded = false;

    private void Awake()
    {
        if (IsClient) GetComponentInChildren<MeshRenderer>().material.color = Color.red; 
        else GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsOwner) return;

        float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
        
        
    }

   
}






