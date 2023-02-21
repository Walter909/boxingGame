using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    private GameObject attackArea;
    public float speed;
    private float distance;

    bool facingLeft = false;

    private Health health;
    private Animator anim;

    private int numberDestroyed = 0;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        spawner = GameObject.Find("Spawner");
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
            numberDestroyed++;
            Destroy(this.gameObject);
        }

        Spawner s = spawner.GetComponent<Spawner>();

        Debug.Log("Number defeated: " + numberDestroyed);
        if (s.numberToSpawn == numberDestroyed)
        {
            Debug.Log("Yay WON!");
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

        Debug.Log(distance);

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
