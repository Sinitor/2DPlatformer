using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttacck;
    private void Update()
    {
        if (timeBtwAttack <= 0 )
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<HP>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttacck;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    } 
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.color = Color.red;
    }
}
