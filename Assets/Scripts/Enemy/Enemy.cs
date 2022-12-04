using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    public float moveSpeed = 500f;

    public DetectionZone detectionZone;

    Rigidbody2D rb;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

     void FixedUpdate() {
        //if the player is in range, the enemy move to the player with the run animation
        if(detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            animator.SetBool("IsMoving", true);
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
        //If the player is not in range, the enemy stay with the idle animation 
        if(detectionZone.detectedObjs.Count == 0)
        {
            animator.SetBool("IsMoving", false);
        }

    }

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

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
