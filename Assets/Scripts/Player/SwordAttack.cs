using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{   
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;
    public float swordDamage = 2;
    public float knockbackPower = 1500f;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider.enabled = false;
        rightAttackOffset = transform.position;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Sword touch");
        //can attack all things declared as "Damageable" with the tag
        if (other.tag == "Damageable")
        {
            Debug.Log("Good tag");
            IDamageable damageable = other.GetComponent<IDamageable>();

            if(damageable != null)
            {
                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
                Vector2 direction = (Vector2) (other.gameObject.transform.position - gameObject.GetComponentInParent<Transform>().position).normalized;
                Vector2 knockback = direction * knockbackPower;

                damageable.TakeDamage(swordDamage, knockback);
            }
            else{
                Debug.LogWarning("Does not implement IDamageable");
            }
        }
        
        //Old script to attack without knockback and only enemy
        /*  if(other.tag == "Enemy")
         {
            //deal damage to the enemy only if he has the tag
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy!=null)
            {
                
                enemy.TakeDamage(swordDamage);
            }
        } */
         
    }

}
