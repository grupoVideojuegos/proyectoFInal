﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;
    public Vector2 mimCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(posX,mimCamPos.x,maxCamPos.x),
           Mathf.Clamp(posY, mimCamPos.y, maxCamPos.y)
           , transform.position.z);
    }
}
