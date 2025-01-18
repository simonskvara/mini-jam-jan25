using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    public Rigidbody2D rb;

    public float moveSpeed;
    
    private void Update()
    {
        ProcessInputs();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.angularVelocity = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(moveX, moveY);
    }

    private void Move()
    {
        rb.velocity = MoveDirection * moveSpeed;
    }
}
