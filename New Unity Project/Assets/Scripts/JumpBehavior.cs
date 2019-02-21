using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    //Controls the jump height
    [Range(1, 15)]
    public float jumpSpeed;


    //Controls the increase in fall rate
    [Range(1, 5)]
    public float fallSpeedMultiplier;

    //Controls the number of consecutive jumps;
    [Range(1, 2)]
    public int maxJumps;
    int jumps;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //jumps = maxJumps;
    }


    // Update is called once per frame
    void Update()
    {

        if(rb.velocity.y < 0)
        {
            float ySpeed = Physics2D.gravity.y * (fallSpeedMultiplier - 1) * Time.deltaTime + rb.velocity.y;
            rb.velocity = new Vector2(rb.velocity.x, ySpeed);
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump())
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
            jumps--;
        }
    }

    bool canJump()
    {
        return jumps > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if(otherTag.Equals("Floor") || otherTag.Equals("Boundary") || otherTag.Equals("Stalactite"))
        {
            jumps = maxJumps;
        }
    }
}
