using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewNewCharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    public float jumpDelay;

    private Collider2D coll;
    private Rigidbody2D RB;
    private int remainingJump;
    private bool onWall;
    private SpriteRenderer sprite;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        RB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(nameof(InputFunc));
        StartCoroutine(nameof(Move));
        StartCoroutine(JumpReturn());
    }

    void LateUpdate()
    {
        // temporary animation
        if (RB.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else if (RB.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Climbable Wall") && !isGrounded())
        {
            remainingJump = 1;
            onWall = true;
            RB.velocity = Vector2.zero;
            RB.gravityScale = 0;
            StopCoroutine(nameof(Move));
            StartCoroutine(Slide());
        }
        /*
        Debug.DrawRay(col.GetContact(0).point,col.GetContact(0).normal,Color.blue,5f );
        if (col.gameObject.layer == 7)
        {
            if (col.GetContact(0).normal.y == 1f)
            {
                remainingJump = 1;
            }
            //if (col.GetContact(0).normal.x is 1 or -1)
            else if (col.gameObject.CompareTag("Climbable Wall") && RB.velocity.y != 0) //and not on ground
            {
                onWall = true;
                RB.velocity = Vector2.zero;
                remainingJump = 1;
                RB.gravityScale = 0;
                StopCoroutine(nameof(Move));
                StartCoroutine(Slide());
            }
        }
        */

    }

    /*
    private IEnumerator OnCollisionStay2D(Collision2D collision)
    {
        yield return null;
        if (collision.gameObject.layer == 7)
        {
            if (collision.GetContact(0).normal.y == 1f)
            {
                remainingJump = 1;
            }
        }
    }
    */

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            RB.gravityScale = 2.5f;
            StopCoroutine(nameof(Slide));
            if (remainingJump == 1) // if collision exit wasn't because of a jump
            {
                StartCoroutine(nameof(Move));
            }

            onWall = false;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, RB.velocity.y);
            yield return null;
        }
    }

    IEnumerator Jump()
    {
        if (isGrounded() || onWall || remainingJump == 1)
        {
            StopCoroutine(nameof(JumpReturn));
            remainingJump = 0;
            if (!onWall)
            {
                StopCoroutine(nameof(Move));
                RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, jumpSpeed);
                yield return new WaitForSeconds(jumpDelay);
                if (!onWall)
                {
                    StartCoroutine(nameof(Move));
                }
            }
            
            else
            {
                float jumpDirection;
                if (sprite.flipX)
                {
                    jumpDirection = 0.5f;
                    if (Input.GetKey(KeyCode.D))
                    {
                        jumpDirection *= 2;
                    }
                }
                else
                {
                    jumpDirection = -0.5f;
                    if (Input.GetKey(KeyCode.A))
                    {
                        jumpDirection *= 2;
                    }
                }
                RB.velocity = new Vector2(jumpDirection*movementSpeed, jumpSpeed);
                yield return new WaitForSeconds(jumpDelay);
                if (!onWall)
                {
                    StartCoroutine(nameof(Move));
                }

                StartCoroutine(JumpReturn());
            }
        }
    }

    IEnumerator InputFunc()
    {
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Jump());
                yield return new WaitForSeconds(jumpDelay);
            }

            yield return null;
        }
    }

    IEnumerator Slide()
    {
        yield return new WaitForSeconds(1);
        if (onWall)
        {
            RB.gravityScale = 0.5f;
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, 1<<7);
    }

    IEnumerator JumpReturn()
    {
        while (true)
        {
            if (isGrounded())
            {
                remainingJump = 1;
            }
            yield return null;  
        }
    }
}
