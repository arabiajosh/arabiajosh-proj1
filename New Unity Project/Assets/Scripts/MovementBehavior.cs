using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [Range(1, 5)]
    public float moveSpeed;

    float maxMoveSpeed;
    float xSpeed;

    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        maxMoveSpeed = 2.5f * moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = Mathf.Clamp(xSpeed + moveSpeed, -maxMoveSpeed, maxMoveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            xSpeed = Mathf.Clamp(xSpeed - moveSpeed, -maxMoveSpeed, maxMoveSpeed);
        }

        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        anim.SetFloat("xSpeed", xSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Boundary"))
        {
            xSpeed = 0f;
        }
    }
}
