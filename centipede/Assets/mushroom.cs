using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }
    }
}
