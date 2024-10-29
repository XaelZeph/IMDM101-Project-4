using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miceScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public int speed = 5;
        private bool isFacingRight = true;

    void Update() 
    {
        Flip();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time % 2 == 0) {
            rb.velocity = new Vector2(speed, 0);
            speed *= -1;
        }

    }

        private void Flip()
    {
        if (isFacingRight && speed < 0 || !isFacingRight && speed > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
