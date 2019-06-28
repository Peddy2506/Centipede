using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour

{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<CentipedeAI>();
        transform.position += new Vector3(0, -speed);
}
