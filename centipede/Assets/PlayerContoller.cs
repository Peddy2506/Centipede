
// PlayerController.cs
// 6/28
// Casper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{
    public float speed = 1f;

 
    void Start()
    {

    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Insect Head")
        {
            Reload();
        }
    }
}
