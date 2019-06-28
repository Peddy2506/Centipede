using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 1;

    void Update()
    {
        transform.position += Vector3.up * speed;
    }
}
