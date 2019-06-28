using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAI : MonoBehaviour
{
    public Vector2Int position;
    List<Vector2> lastPositions = new List<Vector2>();
    public GameObject[] bodyparts;
    public float speed;

    void HeadMove()
    {
        lastPositions[0] = transform.position;
        transform.position += new Vector3(speed, 0);
    }


    void MoveSegment(int currentSegment)
    {
        lastPositions[currentSegment + 1] = bodyparts[currentSegment].transform.position;
        bodyparts[currentSegment].transform.position = lastPositions[currentSegment];
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < bodyparts.Length + 1; i++)
        {
            lastPositions.Add(Vector2.zero);
        }
    }

    void Move(Vector2Int newPosition)
    {
        lastPositions.Add(position);
        position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {

        HeadMove();
        for(int i = 0; i < bodyparts.Length; i++)
        {
            MoveSegment(i);
        }
        


        //transform.position = new Vector3(position.x * scale, position.y * scale, 0);

    }
}
