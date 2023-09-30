using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ShipScript : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    public float boundary;
    private const int maxLevel = 30;
    [Range(1,maxLevel)]
    public int level = 1;

    private int[] chance = new[] { 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 4, 4, 4, 4 }; 
    public float ballVelocityMult = 0.02f;
    public GameObject Ball;
    private static Collider2D[] colliders = new Collider2D[50];
    private static ContactFilter2D contactFilter = new ContactFilter2D();
    public GameDataScript gameData;
    private static bool gameStarted = false;
    public List<GameObject> BlocksList;
    private bool check = false;
    

    void CreateBlocks( float xMax, float yMax, int count, int maxCount)
    {
        if (count > maxCount)
            count = maxCount;
        for (int i=0;i<count; i++)
        for (int k = 0; k < 20; k++)
        {
             
           var obj = Instantiate(BlocksList[chance[Random.Range(0,chance.Length-1)]], new Vector3((Random.value * 2 - 1) * xMax, Random.value * yMax, 0),
                Quaternion.identity);
           if (obj.GetComponent<Collider2D>().OverlapCollider(contactFilter.NoFilter(),colliders) == 0)
               break;
           Destroy(obj);
        }
    }
    
    void CreateBalls(int b)
    {
        for (int i = 0; i < b; i++)
        {
            var obj = Instantiate(Ball);
            var balll = obj.GetComponent<BallScript>();
            balll.ballInitialForce += new Vector2(10 * i, 0);
            balll.ballInitialForce *= 1 + level * ballVelocityMult;
        }
    }
    public void BallDestroyed()
    {
        gameData.balls--;
        StartCoroutine(BallDestroyedCoroutine());
    }

    IEnumerator BallDestroyedCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (GameObject.FindGameObjectsWithTag("Ball").Length==0)
            if (gameData.balls==0)
            CreateBalls(1);
            else
            {
                gameData.Reset();
                SceneManager.LoadScene("SampleScene");
            }
    }

    IEnumerator BlockDestroyedCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            gameData.Reset();
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void BlockDestroyed(int points)
    {
        gameData.points += points;
        StartCoroutine(BlockDestroyedCoroutine());
    }
    void StartLevel()
    {
        var yMax = Camera.main.orthographicSize * 0.8f;
        var xMax = Camera.main.orthographicSize * Camera.main.aspect * 0.85f;
        CreateBlocks(xMax,yMax,level,60);
        CreateBalls(1);
    }
    void Start()
    {
        Cursor.visible = false;
        if (!gameStarted)
        {
            gameStarted = true;
            if (gameData.resetOnStart) gameData.Reset();
        }
        StartLevel();

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5,4,Screen.width - 10,100), string.Format("<color=red><size=30>Score <b>{0}</b>Money <b>{1}</b></size></color>",gameData.points,gameData.money));
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
             Debug.Log("pupka");
         }

         if (pos.x > boundary)
         {
             transform.position = new Vector3(boundary, pos.y, pos.z);
             Debug.Log("pupka");
         }
    }
    public void lengthPlus()
    {
        var oldscale = transform.localScale;
        Vector3 scale = new Vector3(oldscale.x+1,oldscale.y,oldscale.y);
        gameObject.transform.localScale = scale;
        boundary=boundary-(float)0.5;
    }

    public void Magnet()
    {
        
    }

    public void Plus1Ball()
    {
        CreateBalls(1);
    }

    public void Plus2Ball()
    {
        CreateBalls(2);
    }

    public void Plus5Ball()
    {
        CreateBalls(5);
    }
}
