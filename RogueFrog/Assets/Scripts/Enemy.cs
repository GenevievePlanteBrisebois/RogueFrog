using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed = -1f;

    //setters
    public void setSpeed(float s) {
        speed = s;
    }

    //getters
    public float getSpeed()
    {
        return speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    //function for enemy movement
    private void moveEnemy() {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

        if (transform.position.x > (Screen.width / 100f) / 2f + 1f) {
            transform.position = new Vector2(-transform.position.x+1f, transform.position.y);
                
                }
        else if (transform.position.x < -(Screen.width / 100f) / 2f -1f) {
            transform.position = new Vector2(-transform.position.x - 1f, transform.position.y);

        }

    }
}
