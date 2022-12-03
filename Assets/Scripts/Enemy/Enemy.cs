using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
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
