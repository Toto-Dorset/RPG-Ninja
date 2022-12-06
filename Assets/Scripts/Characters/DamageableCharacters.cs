using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacters : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;

    public HealthBarBehavior healthBarBehavior;

    public float maxHealth;
    [SerializeField] GameObject damageText;

    public float Health{

        set{
        if (value < _health)
        {
            animator.SetTrigger("hit");
            healthBarBehavior.SetHealth(_health, maxHealth);
            RectTransform txtTransform = Instantiate(damageText).GetComponent<RectTransform>();
            txtTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            txtTransform.SetParent(canvas.transform);
        }

        _health=value;

        if(_health <= 0)
        {
            if(animator.gameObject.tag == "Player")
                animator.SetTrigger("death");
            else
                Die();
        }}
        get{
            return _health;
        }
    }

    public float _health = 1;


    private void Start() {
        maxHealth = _health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBarBehavior.SetHealth(_health, maxHealth);
    }


    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        Debug.Log("TakeDamage function is called");
        Health -= damage;
        rb.AddForce(knockback);
    }  

    public void Die()
    {
        Destroy(gameObject);
    }

}
