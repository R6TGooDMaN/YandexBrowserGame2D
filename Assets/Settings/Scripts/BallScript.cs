using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float deltaX;
    private Vector2 ballInitialForce;
    private Rigidbody2D rg;
    public GameObject playerObj;
    
    void Start()
    {
       /* ballInitialForce = new Vector2(100.0f, 300.0f);
        ballIsActive = false;
        ballPosition = transform.position;*/
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
       /* if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                rg.AddForce(ballInitialForce);
                ballIsActive = !ballIsActive;
            }

            if (!ballIsActive && playerObj != null)
            {
                ballPosition.x = playerObj.transform.position.x;
                transform.position = ballPosition;
            }
        }*/
    }
}
