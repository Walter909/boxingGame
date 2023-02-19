using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float speed;
    private float distance;

    bool facingLeft = false;

    private Health health;
    private Animator anim;

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
        if (health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
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

        Debug.Log(distance);

        if (distance > 150)
        {
            anim.SetBool("isAttacking", false);
            transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("isAttacking", true);
        }

    }

    // Reduce health on collisions with Devil
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Mike")
        {
            Debug.Log("Touched enemy from " + collision.name);
            rb.velocity = Vector2.zero;
            health.TakeDamage(2);
        }

    }
}
