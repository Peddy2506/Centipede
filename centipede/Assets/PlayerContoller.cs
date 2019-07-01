// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed = .05f;

 
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 pos = transform.position;
        Rigidbody2D rb = GetComponent < Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector2.down * speed;
        }

        
    
        
 
    }
}
