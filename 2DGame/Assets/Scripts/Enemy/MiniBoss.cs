using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MiniBoss : EnemyMove
{
    private Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttacck;
    public int damage;
    public TextMeshProUGUI dialog;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (dialog == null)
        {
            anim.SetBool("Move", true);
           Angry();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((timeBtwAttack <= 0))
        {
            if (collision.gameObject.tag == "Player")
            {
                anim.SetTrigger("Attack");
                collision.GetComponent<PlayerHP>().TakeDamage(damage);
                timeBtwAttack = startTimeBtwAttacck;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((timeBtwAttack <= 0))
        {
            if (collision != null)
            {
                if (collision.gameObject.tag == "Player")
                {
                    anim.SetTrigger("Attack");
                    collision.GetComponent<PlayerHP>().TakeDamage(damage);
                    timeBtwAttack = startTimeBtwAttacck;
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
