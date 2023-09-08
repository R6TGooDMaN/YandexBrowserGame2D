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
        Cursor.visible = false;
        //dir = gameObject.transform.position;

    }
    
    
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        transform.position = pos;
        /* dir.x += Input.GetAxis("Horizontal") * speed*Time.deltaTime;
         transform.position = dir;
         if (dir.x < -boundary)
         {
             transform.position = new Vector3(-boundary, dir.y, dir.z);
         }

         if (dir.x > boundary)
         {
             transform.position = new Vector3(boundary, dir.y, dir.z);
         }*/
    }
    
}
