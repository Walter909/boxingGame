using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    //enemy punch soundFX
    //[SerializeField] private AudioSource enemyPunchEffect;
    public GameObject player;
    private Rigidbody2D rb;

    private GameObject attackArea;
    public float speed;
    private float distance;

    bool facingLeft = false;

    private Health health;
    private Animator anim;
    private GameObject devils;
    private static int countDestroyed = 0;

    public Canvas m_Canvas;
    public WinScene winScene;


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

    void Flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

    void FixedUpdate()
    {
        if (health.currentHealth == 0)
        {
            countDestroyed++;
            gameObject.SetActive(false);
        }

        if (countDestroyed == 6)
        {
            m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            winScene.Setup();
            Time.timeScale = 0;
            Debug.Log("Yay Gameover");
            countDestroyed = 0;
        }

        //Where is Devil facing 
        if (rb.transform.position.x > 0 && facingLeft)
        {
            Flip();
        }
        if (rb.transform.position.x < 0 && !facingLeft)
        {
            Flip();
        }

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > 150)
        {
            anim.SetBool("isAttacking", false);
            attackArea.SetActive(false);
            transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attackArea.SetActive(true);
        }

    }

    // When you hit Mike kill momentum
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Mike")
        {
            Debug.Log("Touched enemy from " + collision.collider.tag);
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }

    }
}