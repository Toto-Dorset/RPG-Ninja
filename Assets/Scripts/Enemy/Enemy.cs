using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    public DetectionZone detectionZone;

    public float moveSpeed = 500f;

    Rigidbody2D rb;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

     void FixedUpdate() {
        if(detectionZone.detectedObjs.Count >= 0){
            Vector2 direction =(Vector2) (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
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
