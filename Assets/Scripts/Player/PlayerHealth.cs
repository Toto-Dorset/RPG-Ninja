using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float _healt = 3f;
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
