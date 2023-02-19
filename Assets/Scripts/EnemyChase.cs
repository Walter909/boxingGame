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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();

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
            transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
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
