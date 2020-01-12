using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float MoveSpeed = 3f;
    int wayPointIndex = 0;
    bool reverse = false;
    List<Transform> wayPointsReverse;
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
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var nexPos = wayPoints[wayPointIndex].transform.position;
            var movement = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nexPos, movement);
            
            if (transform.position == nexPos)
            {
                wayPointIndex++;
                
            }
            if (wayPointIndex == wayPoints.Count)
            {
                wayPointIndex = 0;
                wayPoints.Reverse();
                transform.localScale = new Vector3(transform.localScale.x*-1f,1f,1f);
            }
            
        }
        
    }
}
