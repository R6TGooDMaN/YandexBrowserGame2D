using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "GameData", menuName = "GameData", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool resetOnStart;

    public int balls = 1;

    public int points = 0;
    public int money = 0;
   
   
    void Start()
    {
        
    }

    public void Reset()
    {
        balls = 0;
        points = 0;
    }

    void Update()
    {
        
    }
}
