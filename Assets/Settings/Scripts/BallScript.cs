using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float deltaX;
    public Vector2 ballInitialForce;
    private Rigidbody2D rg;
    public GameObject playerObj;
    
    void Start()
    {
       
        rg = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Test");
        deltaX = transform.position.x;
    }

    
    void Update()
    {
        if (rg.isKinematic)
            if (Input.GetButtonDown("Fire1"))
            {
                rg.isKinematic = false;
                rg.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos;
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
