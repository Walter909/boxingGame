using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public Animator anim;
    //Devil does damage after attacking 
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Health>() != null)
        {
            Debug.Log("Just hit the " + collider2D.tag);
            Health h = collider2D.GetComponent<Health>();
            h.TakeDamage(2);
            anim.SetTrigger("takeDamage");
        }

    }
}
