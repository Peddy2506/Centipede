using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public KeyCode fire = KeyCode.Space;

    
    void Update()
    {
        if (Input.GetKeyDown(fire))
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position; 
        }
    }
}
