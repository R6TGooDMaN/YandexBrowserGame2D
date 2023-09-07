using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    
    
    void Start()
    {
        dir = gameObject.transform.position;
        
    }
    
    
    void Update()
    {
        Vector2 vector2 = new Vector2(Input.GetAxis("Horizontal") , 0 )*speed;
        transform.Translate(vector2, Space.Self);
    }
    
}
