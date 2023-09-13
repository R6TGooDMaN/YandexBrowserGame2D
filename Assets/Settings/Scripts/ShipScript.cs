using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipScript : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    public float boundary;
    private const int maxLevel = 30;
    [Range(1,maxLevel)]
    public int level = 1;

    public float ballVelocityMult = 0.02f;
    public GameObject Block;
    public GameObject Ball;
    private static Collider2D[] colliders = new Collider2D[50];
    private static ContactFilter2D contactFilter = new ContactFilter2D();

    void CreateBlocks(GameObject prefab, float xMax, float yMax, int count, int maxCount)
    {
        if (count > maxCount)
            count = maxCount;
        for (int i=0;i<count; i++)
        for (int k = 0; k < 20; k++)
        {
             
           var obj = Instantiate(prefab, new Vector3((Random.value * 2 - 1) * xMax, Random.value * yMax, 0),
                Quaternion.identity);
           if (obj.GetComponent<Collider2D>().OverlapCollider(contactFilter.NoFilter(), colliders) == 0)
               break;
           Destroy(obj);
        }
    }

    void CreateBalls()
    {
        int count = 2;
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(Ball);
            var balll = obj.GetComponent<BallScript>();
            balll.ballInitialForce += new Vector2(10 * i, 0);
            balll.ballInitialForce *= 1 + level * ballVelocityMult;
        }
    }
    void StartLevel()
    {
        var yMax = Camera.main.orthographicSize * 0.8f;
        var xMax = Camera.main.orthographicSize * Camera.main.aspect * 0.85f;
        CreateBlocks(Block,xMax,yMax,level,60);
        CreateBalls();
    }
    void Start()
    {
        Cursor.visible = false;
        StartLevel();

    }
    
    
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        transform.position = pos;
       
         if (pos.x < -boundary)
         {
             transform.position = new Vector3(-boundary, pos.y, pos.z);
         }

         if (pos.x > boundary)
         {
             transform.position = new Vector3(boundary, pos.y, pos.z);
         }
    }
    
}
