using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private Rigidbody2D rg;
    public GameObject playerObj;
    
    void Start()
    {
        ballInitialForce = new Vector2(100.0f, 300.0f);
        ballIsActive = false;
        ballPosition = transform.position;
        rg = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump") == true)
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
        }
    }
}
