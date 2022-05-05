using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : EnemyMove
{
    private Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttacck;
    public int damage;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position,player.position) <= angryDistance)
        {
            anim.SetTrigger("Run");
            angryDistance = 20;
            Angry();
        }
        if (Vector2.Distance(transform.position, player.position) >= angryDistance)
        {
            Walk();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((timeBtwAttack <= 0))
        {
            if (collision.gameObject.tag == "Player")
            {
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
        if (collision != null)
        {
            if ((timeBtwAttack <= 0))
            {
                if (collision.gameObject.tag == "Player")
                {
                    collision.GetComponent<PlayerHP>().TakeDamage(damage);
                    timeBtwAttack = startTimeBtwAttacck;
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
}
