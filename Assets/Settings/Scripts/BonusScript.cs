using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class BonusScript : MonoBehaviour
{
    private ShipScript shipScript;
    public Typebonus bonus;
    public enum Typebonus
    {
        LengthBonus,
        MagnetBonus,
        Plus1BallBonus,
        Plus2BallBonus,
        Plus5BallBonus,
        SlowBonus,
        SpeedBonus
    }
    // Start is called before the first frame update
    void Start()
    {
        shipScript = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            if (bonus == Typebonus.LengthBonus)
            {
                shipScript.lengthPlus();
                Debug.Log("LENGTH");
            }

            if (bonus == Typebonus.MagnetBonus )
            {
                Debug.Log("MAGNET");
               
            }

            if (bonus == Typebonus.Plus1BallBonus )
            {
                shipScript.Plus1Ball();
                Debug.Log("PLUSONE");
                
            }

            if (bonus == Typebonus.Plus2BallBonus )
            {
                shipScript.Plus2Ball();
                Debug.Log("PLUSTWO");
              
            }

            if (bonus == Typebonus.Plus5BallBonus )
            {
                shipScript.Plus5Ball();
                Debug.Log("PLUSFIVE");
                
            }
            Destroy(gameObject);
    }
}
