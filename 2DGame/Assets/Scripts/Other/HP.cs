using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float health;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    { 
        anim.SetTrigger("Damage");
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    } 
    private void Die()
    {
        Destroy(gameObject);
    }
}
