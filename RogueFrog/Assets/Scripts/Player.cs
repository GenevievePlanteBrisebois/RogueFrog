﻿/*
 *Created by : Genevieve Plante-Brisebois
 * Date: May 11, 2020
 * 
 * This game is created to learn unity and C#. Tutorials taken from Udemy.
 * 
 * This class is the player class an contains all the information and methods that concern the player. 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //setting event controllers to communicate with the game controller
    public delegate void PlayerHandler();
    public event PlayerHandler PlayerMoved;
    public event PlayerHandler PlayerNextLevel;


    //setting public variables
    public float distance = 0.32f;

    //setting private variables
    private bool jumping;
    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        //setting variables to their initial values
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

    }


    //method to check for player movement
    private void playerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 aimingPosition = Vector2.zero;
        Collider2D hitCollider =  null;
        bool attemptingMvmt = false;

        //player did not move previously and is now pressing a key
        if (!jumping)
        {
            //left
            if (horizontalMovement < 0)
            {
                aimingPosition = new Vector2(transform.position.x - distance, transform.position.y);
                attemptingMvmt = true;
            }
            //right
            else if (horizontalMovement > 0)
            {
                aimingPosition = new Vector2(transform.position.x + distance, transform.position.y);
                attemptingMvmt = true;
            }
            //down
            else if (verticalMovement < 0)
            { 
                aimingPosition = new Vector2(transform.position.x, transform.position.y - distance);
                attemptingMvmt = true;
            }
            //up
            else if (verticalMovement > 0)
            { 
                aimingPosition = new Vector2(transform.position.x, transform.position.y + distance);
                attemptingMvmt = true;
            }

        //validate if there is a collision with an obstacle for that place. 
        hitCollider = Physics2D.OverlapCircle(aimingPosition, 0.1f);

            if (hitCollider == null && attemptingMvmt ==true) {
                transform.position = aimingPosition;
                jumping = true;
                //checking with the game controller
                if(PlayerMoved != null)
                {
                    PlayerMoved();
                }
            }

        }
        //player moved previously and is now not pressing any keys
        else
        {
            if (horizontalMovement == 0 && verticalMovement == 0)
                jumping = false;
        }

        //checking boudaries
        checkBoundaries();
 
    }

    private void checkBoundaries() {
        //case left boundary
        if (transform.position.x < -(Screen.width / 100f) / 2f)
        {
            //Debug.Log(Screen.width + " "+Screen.height);
            transform.position = new Vector2(transform.position.x + distance, transform.position.y);
        }
        //case right boundary
        else if (transform.position.x > (Screen.width / 100f) / 2f)
        {
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
        }
        //case bottom boundary
        else if (transform.position.y < -(Screen.height / 100f) / 2f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + distance);
        }
        //case top boundary ==> this case needs to add 1 to the score and bring player back at the initial starting point
        else if (transform.position.y > (Screen.height / 100f) / 2f)
        {
            transform.position = startingPosition;
            //check with  game controller for new level
            if(PlayerNextLevel != null)
            {
                PlayerNextLevel();
            }
        }
    }
}
