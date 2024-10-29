using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    float timeRelative = 0;

    bool running = false;

    const string idle1 = "idle 1";
    const string idle2 = "idle 2";
    const string idle3 = "idle 3";
    const string idle4 = "sleep";
    const string run = "run";
    const string jump = "jump";
    const string jumpInPlace = "jump 2";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timeChecker();

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.7f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (horizontal > 0f) {
            running = true;
        }
        else{
            running = false;
        }
        animator.SetBool("running", running);

        animator.SetBool("grounded", IsGrounded());

    }

    private void timeChecker() 
    {
        timeRelative = Time.time % 20;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}