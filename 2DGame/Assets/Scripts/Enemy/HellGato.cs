using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellGato : EnemyMove
{
    private float timeBtwAttack;
    public float startTimeBtwAttacck;
    public int damage; 

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= angryDistance)
        {
            Walk();
        }
        if (Vector2.Distance(transform.position, player.position) <= angryDistance)
        {
            angryDistance = 20;
            Angry();
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
