using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    Animator animator;

    public float moveSpeed = 500f; //set to 500 by default but can be modified in the Inspector in Unity for each enemy

    public DetectionZone detectionZone;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float damage = 1f;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

     void FixedUpdate() {
        //if the player is in range, the enemy move to the player with the run animation
        if(detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            animator.SetBool("IsMoving", true);

            if(direction.x < 0)//flip the enemy to watch in the player direction
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            //rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime); //try another way to move to compare
        }
        //If the player is not in range, the enemy stay with the idle animation 
        if(detectionZone.detectedObjs.Count == 0)
        {
            animator.SetBool("IsMoving", false);
        }

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable damageable = other.collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.TakeDamage(damage);
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
