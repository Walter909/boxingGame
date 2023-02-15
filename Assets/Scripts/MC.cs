using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MC : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public int moveSpeed;

    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }


    public void OnWalk(InputAction.CallbackContext context)
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

    public void OnPunch(InputAction.CallbackContext context)
    {
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
}
