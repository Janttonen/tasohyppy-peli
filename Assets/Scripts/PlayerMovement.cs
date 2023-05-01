using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    // [SerializeField] ability to see script valuables in Unity
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 14f;

    // get terrain component
    [SerializeField] private LayerMask jumpGround;

    private enum MovementState { idle, running, jump, fall }
    private void Start()
    {
        // get components of Player
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // pink character faster and can jump higher
        if (GameObject.FindWithTag("OtherPlayer")){
            jumpForce = 25f;
            moveSpeed = 14f;
        }
        // character movement horizontally
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // character jumps, if 'jump' button is pressed and player in ground
        if (Input.GetButtonDown("Jump") && InGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;

        // Animator animation idle -> running, if players horizontal position changes
        // when player moves to right
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        // when player moves to left
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // animation change when jumping, checks players position in y- axel
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state", (int)state);
    }

    // limit jumpin to only one time
    private bool InGround()
    {
        // create secondary box for player (same kind of as boxCollider2D)
        // created box locates a bit more downwards than boxCollider
        // if there is overlap with created box and platform, character in not jumping
        // boolean returns true if in ground
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
