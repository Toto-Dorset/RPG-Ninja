using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacters : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;

    public float Health{

        set{health=value;
        if(health <= 0)
        {
            Die();
        }}
        get{return health;
        }
    }

    public float health = 1;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        Health -= damage;

        /* if(health <= 0)
        {
            Die();
        } */
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        animator.SetTrigger("hit");
        Health -= damage;
        rb.AddForce(knockback);
    }  

    public void Die()
    {
        Destroy(gameObject);
    }

}
