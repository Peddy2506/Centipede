// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifetime = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Insect Head")
        {
            CentipedeAI cai = other.GetComponent<CentipedeAI>();
            Destroy(cai.bodyparts[cai.bodyparts.Count - 1]);
            cai.bodyparts.RemoveAt(cai.bodyparts.Count - 1);
            cai.position = cai.lastPositions[cai.lastPositions.Count - 1];
            cai.lastPositions.RemoveAt(cai.lastPositions.Count - 1);
        }

/*        if (collision.gameObject.tag == "Insect Body")
        {
           TODO: Insert code that seperates Insect Body 
        }
*/
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(gameObject);
        transform.position += Vector3.up;

    }
}
