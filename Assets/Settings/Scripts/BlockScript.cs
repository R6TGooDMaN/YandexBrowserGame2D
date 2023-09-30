using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockScript : MonoBehaviour
{
    private ShipScript shipScript;

    public int points;
    private Animator anim;
    private int Health = 2 ;
    public Typeblock type;
    public GameObject funt;
    public List<GameObject> BonusList;
    private int[] chance = new[] { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 4, 4, 4, 4 }; 
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
        }
        else if (Health == 0)
        {
            if (type == Typeblock.Gold)
            {
                Instantiate(funt, transform.position, transform.rotation);
            }
            if (type == Typeblock.Rainbow)
            {
                Instantiate(BonusList[chance[Random.Range(0,chance.Length-1)]],transform.position,transform.rotation);
            }
            Destroy(gameObject);
            points++;
            shipScript.BlockDestroyed(points); 
        }
    }
}