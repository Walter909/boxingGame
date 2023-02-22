using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MC : MonoBehaviour
{

    //punch soundFX
    [SerializeField] private AudioSource punchEffect;
    
    //Dealing damage
    private Health health;
    private GameObject attackArea;

    //Moving
    public int moveSpeed;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    bool facingLeft = true;

    bool isPunchTime = false;

    private float timePassed = 0f;

    //Scenes
    public GameOverScreen gameOverScreen;

    public Canvas m_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Heal player health periodically
        timePassed += Time.deltaTime;
        if (timePassed > 5f && health.currentHealth < 10)
        {
            Debug.Log("Healing");
            health.HealDamage(2);
            timePassed = 0f;
        }
        //Show Game Over Screen when Health is 0
        if (health.currentHealth == 0)
        {
            m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            gameOverScreen.Setup();
            Time.timeScale = 0;
        }

        //Show Game win scene when defeated all the enemies

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
        isPunchTime = context.ReadValue<float>() > 0.1f;
        if (isPunchTime)
        {
            anim.SetBool("isPunching", true);
            attackArea.SetActive(true);
            punchEffect.Play();
        }
        else
        {
            anim.SetBool("isPunching", false);
            attackArea.SetActive(false);
        }

    }

    // Should allow walking through devils
    // void OnColliderEnter2D(Collider2D collision)
    // {

    //     if (collision.name == "Devil")
    //     {
    //         Debug.Log("Touched enemy from " + collision.name);
    //     }
    // }
}
//punch soundFX
