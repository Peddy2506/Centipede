
// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 acceleration;
    Vector2 gravity = new Vector2(0, -1);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += Time.deltaTime * (acceleration + gravity);
        Vector3 p = transform.position;
        // Crtl + D to d
        p.x += Time.deltaTime * velocity.x;
        p.y += Time.deltaTime * velocity.y;
        transform.position = p;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        int count = 0;
        Vector2 sum = new Vector2(0, 0);
        while (count < collision.contactCount)
        {
            sum += collision.contacts[count].point;
            count += 1;
        }
        Vector2 average = sum / count;
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 collisionPoint = average - position;
        if (Mathf.Abs(collisionPoint.x) > Mathf.Abs(collisionPoint.y))
        {
            velocity.x *= -1;
        }
        else
        {
            velocity.y *= -1;
        }
    }
}


    
