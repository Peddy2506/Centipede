// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifetime = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Insect Head")
        {
            CentipedeAI cai = collision.gameObject.GetComponent<CentipedeAI>();
            cai.bodyparts.RemoveAt(cai.bodyparts.Count - 1);
            cai.position = cai.lastPositions[0];
            cai.lastPositions.RemoveAt(0);
        }
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(gameObject);
        transform.position += Vector3.up;

    }
}
