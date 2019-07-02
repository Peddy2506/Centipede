
// CentipedeAI
// June 28, 2019
// @author Peter Lee


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAI : MonoBehaviour
{
    public bool facingRight = false;
    public float framesPerSecond;
    float secondsPerFrame;
    public float timeUntilChange;
    public Vector2Int position;
    public List<Vector2Int> lastPositions = new List<Vector2Int>();
    public List<GameObject> bodyparts;
    public float speed;
    bool hasCollided = false;

    void UpdateSecondsPerFrame()
    {
        if (framesPerSecond <= 0)
            framesPerSecond = 0.0001f;
        secondsPerFrame = 1f / framesPerSecond;
    }

    void Move()
    {
        if (facingRight)
        {
            Move(position + Vector2Int.right);
        }
        else
        {
            Move(position + Vector2Int.left);
        }
    }


    void MoveSegment(int currentSegment)
    {
        bodyparts[currentSegment].transform.position = new Vector3(lastPositions[currentSegment].x, lastPositions[currentSegment].y, 0) * speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateSecondsPerFrame();
        timeUntilChange = secondsPerFrame;
        position = new Vector2Int((int)(transform.position.x / speed), (int)(transform.position.y / speed));
        for(int i = 0; i < bodyparts.Count + 1; i++)
        {
            lastPositions.Add(position);
        }
    }

    void Move(Vector2Int newPosition)
    {
        lastPositions.Add(position);
        lastPositions.RemoveAt(0);
        position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilChange -= Time.deltaTime;
        if (timeUntilChange < 0)
        {
            timeUntilChange = secondsPerFrame;
            Move();
        }
        transform.position = new Vector3(position.x, position.y, 0) * speed;

        for(int i = 0; i < bodyparts.Count; i++)
        {
            MoveSegment(i);
        }
        if (facingRight)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (hasCollided)
            hasCollided = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mushroom")
        {
            Debug.Log("Mushroom");
            facingRight = !facingRight;
            position.y--;
            if (!hasCollided)
            {
                hasCollided = false;
                Move();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("Border");
            facingRight = !facingRight;
            position.y--;
            if (!hasCollided)
            {
                hasCollided = false;
                Move();
            }
        }
    }
}
