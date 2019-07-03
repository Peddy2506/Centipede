// FILENAME.cs
// Created: 7/1/19
// Owner: Jacob
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifetime = 5;
    bool hit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hit)
            return;
        Debug.Log("Hit: " + other.tag);
        if (other.tag == "Insect Head")
        {
            CentipedeAI cai = other.GetComponent<CentipedeAI>();
            Destroy(cai.bodyparts[cai.bodyparts.Count - 1]);
            cai.bodyparts.RemoveAt(cai.bodyparts.Count - 1);
            cai.position = cai.lastPositions[cai.lastPositions.Count - 1];
            cai.lastPositions.RemoveAt(cai.lastPositions.Count - 1);
            cai.UpdateBodyParts();
        }
        else if (other.tag == "Insect Body")
        {
            int index = other.GetComponent<InsectBody>().index;
            Debug.Log("Index: " + index);
            GameObject oldHead = other.GetComponent<InsectBody>().Head;
            CentipedeAI cai = oldHead.GetComponent<CentipedeAI>();
            GameObject newHead = null;
            CentipedeAI cai2 = null;
            if (cai.bodyparts.Count > index)
            {
                Debug.Log("Making new head");
                newHead = Instantiate(oldHead);
                cai2 = newHead.GetComponent<CentipedeAI>();
                cai2.bodyparts = new List<GameObject>();
                newHead.transform.parent = other.transform.parent;
                newHead.transform.position = oldHead.transform.position;

                cai2.position = cai.lastPositions[index];

                Debug.Log("Destroying body part " + (index + 1));
                cai.bodyparts.RemoveAt(index);
                Destroy(cai.bodyparts[index]);
            }
            for (int i = index; i < cai.bodyparts.Count;)
            {
                Debug.Log("Moving body part " + (i + 2));
                if (cai2 != null)
                    cai2.bodyparts.Add(cai.bodyparts[i]);
                cai.bodyparts.RemoveAt(i);
            }

            Destroy(other.gameObject);
            Debug.Log("Updating new heads body lists ");
            cai.UpdateBodyParts();
            if (cai2 != null)
                cai2.UpdateBodyParts();
        }
        else if (other.tag == "Spider")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Mushroom")
        {
            Destroy(other.gameObject);
        }

        hit = true;
        Destroy(gameObject);
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(gameObject);
        transform.position += Vector3.up;

    }
}
