using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    public float boundary;
    
    void Start()
    {
        dir = gameObject.transform.position;
        
    }
    
    
    void Update()
    {
        dir.x += Input.GetAxis("Horizontal") * speed;
        transform.position = dir;
        if (dir.x < -boundary)
        {
            transform.position = new Vector3(-boundary, dir.y, dir.z);
        }

        if (dir.x > boundary)
        {
            transform.position = new Vector3(boundary, dir.y, dir.z);
        }
    }
    //Pisichki sisichki popochki
}
