using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MC : MonoBehaviour
{
    //Dealing damage
    private Health health;

    //Moving
    public int moveSpeed;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Show Game Over Screen
        // if (health.currentHealth <= 0)
        // {

        // }
    }


    void OnWalk(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        anim.SetFloat("isWalking", Mathf.Abs(moveInput.x));

        if (moveInput.x > 0 && facingLeft)
        {
            Flip();
        }
        if (moveInput.x < 0 && !facingLeft)
        {
            Flip();
        }


        rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }
    void Flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

    void OnPunch(InputAction.CallbackContext context)
    {
        //Play Punch animation
        bool isPunchTime = context.ReadValue<float>() > 0.1f;
        if (isPunchTime)
        {
            Debug.Log("Pressed so pucnch");
            anim.SetBool("isPunching", true);
        }
        else
        {
            Debug.Log("Done Punching");
            anim.SetBool("isPunching", false);
        }

    }

    // Reduce health on collisions with Devil
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Devil")
        {
            Debug.Log("Touched enemy from " + collision.name);
            health.TakeDamage(1);
        }

    }
}
