using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private float speed = 20;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Debug.Log(distance);
        if (distance > 90)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }


    }
}
