
// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2;

/*    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "PlayerController")
        {
            PlayerContoller player = other.GetComponent<PlayerContoller>();
            Destroy(player.PlayerController);
        }
    }
*/


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }
}


    
