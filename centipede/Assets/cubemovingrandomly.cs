using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemovingrandomly : MonoBehaviour
{
    float speed = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity
            = Vector3.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mushroom")
        {
            GetComponent<Rigidbody2D>().velocity
            = Vector3.down * speed;
        }
    }
}
