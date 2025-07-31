using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class PortalTwoScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D meatCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D meatBody;
    [SerializeField] private float meatSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float horizontalFriction;
    [SerializeField] private float jumpStrength;

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
            meatBody.velocity = new Vector2(0, meatBody.velocity.y);
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            Debug.Log("Jump");
            meatBody.velocity += Vector2.up * jumpStrength;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }

        float currX = meatBody.velocity.x;
        
        meatBody.velocity += (1 - Math.Abs(currX) / maxSpeed) * horizontalInput * meatSpeed * Vector2.right;

        if (Math.Abs(horizontalInput) == 0)
        {
            meatBody.velocity = new Vector2(currX * horizontalFriction, meatBody.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(meatCollider.bounds.center, meatCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return groundCheck.collider != null;
    }
}
