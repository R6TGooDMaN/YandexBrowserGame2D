using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private ShipScript shipScript;

    public int points;

    void Start()
    {
        shipScript = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();
    }


    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        Destroy(gameObject);
        points++;
        shipScript.BlockDestroyed(points);
    }
}
