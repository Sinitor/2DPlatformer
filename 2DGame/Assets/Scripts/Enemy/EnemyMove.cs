using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float angryDistance;
    public float distanceRight;
    public float distanceLeft;
    public Transform player;   
    public float Yposition;
    
    public void Walk()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= distanceLeft)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (transform.position.x >= distanceRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    } 
    public void Angry()
    {
        Vector2 onlyX = new Vector2(transform.position.x, Yposition);
        transform.position = Vector2.MoveTowards(onlyX, player.position, speed * Time.deltaTime);
        if (player.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
}
