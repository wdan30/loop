using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalTwoScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D portalCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Rigidbody2D portalBody;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float horizontalFriction;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("I am meat");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            portalBody.velocity = new Vector2(0, portalBody.velocity.y);
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            portalBody.velocity += Vector2.up * jumpStrength;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !IsTouchingWallLeft())
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !IsTouchingWallRight())
        {
            horizontalInput = 1;
        }

        float currX = portalBody.velocity.x;
        
        portalBody.velocity += (1 - Math.Abs(currX) / maxSpeed) * horizontalInput * speed * Vector2.right;

        if (Math.Abs(horizontalInput) == 0)
        {
            portalBody.velocity = new Vector2(currX * horizontalFriction, portalBody.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(portalCollider.bounds.center, portalCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return groundCheck.collider != null;
    }

    private bool IsTouchingWallRight()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(portalCollider.bounds.center, portalCollider.bounds.size, 0, Vector2.right, 0.1f, wallLayer);
        return groundCheck.collider != null;
    }

    private bool IsTouchingWallLeft()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(portalCollider.bounds.center, portalCollider.bounds.size, 0, Vector2.left, 0.1f, wallLayer);
        return groundCheck.collider != null;
    }
}