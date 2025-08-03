using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    private bool goingLeft;

    // Start is called before the first frame update
    void Start()
    {
        goingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGrounded())
        {
            movePlayer();
        }
    }

    private bool checkGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return groundCheck.collider != null;
    }

    private void movePlayer()
    {   
        if (goingLeft)
        {
            RaycastHit2D wallCheck = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.left, 0.1f, groundLayer);

            rb.velocity = speed * Vector2.left;

            if (wallCheck.collider != null)
            {
                goingLeft = false;
            }
        } 
        else
        {
            RaycastHit2D wallCheck = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.right, 0.1f, groundLayer);

            rb.velocity = speed * Vector2.right;

            if (wallCheck.collider != null)
            {
                goingLeft = true;
            }
        }
        
        
    }
}
