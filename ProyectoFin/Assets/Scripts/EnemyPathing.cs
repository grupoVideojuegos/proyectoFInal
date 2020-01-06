using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float MoveSpeed = 3f;
    int wayPointIndex = 0;
    bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        move();
    }
    private void move()
    {
        if (wayPointIndex <= wayPoints.Count - 1 && !reverse)
        {
            var nexPos = wayPoints[wayPointIndex].transform.position;
            var movement = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nexPos, movement);
            Debug.Log("khe");
            if (transform.position == nexPos)
            {
                wayPointIndex++;
                Debug.Log("kheasf");
            }
        }
        else if(wayPointIndex >= 0)
        {
            if(wayPointIndex >= wayPoints.Count)
            {
                transform.localScale = new Vector3( -1f, 1f, 1f);
            }
            var nexPos = wayPoints[wayPointIndex-1].transform.position;
            var movement = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nexPos, movement);
            Debug.Log("khe");
            if (transform.position == nexPos)
            {
                wayPointIndex--;
                Debug.Log("kheasf");
            }

            if(wayPointIndex == 0)
            {
                reverse = false;
            }

        }
    }
}
