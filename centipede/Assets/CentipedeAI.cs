
// CentipedeAI
// June 28, 2019
// @author Peter Lee


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (currentSegment >= bodyparts.Count)
            return;
        if (bodyparts[currentSegment] == null)
        {
            bodyparts.RemoveAt(currentSegment);
            UpdateBodyParts();
        }
        else if (currentSegment >= lastPositions.Count)
        {
            if (lastPositions.Count == 0)
                bodyparts[currentSegment].transform.position = new Vector3(position.x, position.y, 0) * speed;
            else
                bodyparts[currentSegment].transform.position = new Vector3(lastPositions[lastPositions.Count - 1].x, lastPositions[lastPositions.Count - 1].y, 0) * speed;
        }
        else
            bodyparts[currentSegment].transform.position = new Vector3(lastPositions[(lastPositions.Count - 1) - currentSegment].x, lastPositions[(lastPositions.Count - 1) - currentSegment].y, 0) * speed;
    }

    public void UpdateBodyParts()
    {
        for(int i = 0; i < bodyparts.Count; i++)
            bodyparts[i].GetComponent<InsectBody>().index = i;
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
            UpdateBodyParts();
        }
    }

    void Move(Vector2Int newPosition)
    {
        lastPositions.Add(position);
        while (lastPositions.Count > bodyparts.Count)
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

        for(int i = bodyparts.Count - 1; i >= 0; i--)
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

        if (collision.gameObject.tag == "Bottom Border")
        {
            Debug.Log("Bottom");
            SceneManager.LoadScene("gameover");
        }
    }
}
