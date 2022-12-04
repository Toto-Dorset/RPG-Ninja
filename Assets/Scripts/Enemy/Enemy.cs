using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    Animator animator;

    public float moveSpeed = 500f; //set to 500 by default but can be modified in the Inspector in Unity for each enemy

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
            //rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime); //try another way to move to compare
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
        Health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }  

    public void Die()
    {
        Destroy(gameObject);
    }

}
