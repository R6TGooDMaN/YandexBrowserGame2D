using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private ShipScript shipScript;

    public int points;
    private Animator anim;
    private int Health = 2 ;
    public Typeblock type;

    public enum Typeblock
    {
        Gold,
        Green,
        Red,
        Rainbow,
        Purple
    }

    void Start()
    {
        shipScript = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Health--;
        if (Health == 1 )
        {
            if (type == Typeblock.Gold)
            {
                anim.SetBool("DestroyBool",true);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1f)
                {
                    anim.Play("DestroyGold",0,1f);
                }
            }
            
            if (type == Typeblock.Red)
            {
                anim.SetBool("DestroyBool",true);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1f)
                {
                    anim.Play("DestroyRed",0,1f);
                }
            }
            
            if (type == Typeblock.Green)
            {
                anim.SetBool("DestroyBool",true);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1f)
                {
                    anim.Play("DestroyGreen",0,1f);
                }
            }
            
            if (type == Typeblock.Purple)
            {
                anim.SetBool("DestroyBool",true);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1f)
                {
                    anim.Play("DestroyPurple",0,1f);
                }
            }
            
        }
        else if (Health == 0)
        {
            Destroy(gameObject);
            points++;
            shipScript.BlockDestroyed(points); 
        }

    }
}
