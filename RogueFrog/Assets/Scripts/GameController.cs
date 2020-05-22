﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //declaring variables
    public Player player;
    public Text LevelText;
    public Text ScoreText;

    private int score=0;
    private int level=0;
    private float highestPosition;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        level = 0;
        player.PlayerMoved += PlayerMoved;
        player.PlayerNextLevel += PlayerNextLevel;
        highestPosition = player.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {

        


    }

    void PlayerMoved() {
        if (player.transform.position.y > highestPosition)
        {
            highestPosition = player.transform.position.y;
            score++;
            ScoreText.text = "Score: " + score.ToString();
            
        }
    }

    void PlayerNextLevel()
    {
        highestPosition = player.transform.position.y;
        level++;
        LevelText.text = "Level: " + level;
        
    }
}
