using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacters : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;

    public float Health{

        set{_health=value;
        if(_health <= 0)
        {
            if(animator.gameObject.tag == "Player")
                animator.SetTrigger("death");
            else
                Die();
        }}
        get{return _health;
        }
    }

    public float _health = 1;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        Health -= damage;
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        Debug.Log("TakeDamage function is called");
        animator.SetTrigger("hit");
        Health -= damage;
        rb.AddForce(knockback);
    }  

    public void Die()
    {
        Destroy(gameObject);
    }

}
