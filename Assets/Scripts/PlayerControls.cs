using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    //declare private variables
    private float x_pos;

    //declare public variables
    public float xLimitUpper;
    public float xLimitLower;
    public int lives;
    public int score;

    // Use this for initialization
    void Start () {
        x_pos = xLimitLower;
        transform.position = new Vector3(x_pos, -4.0f);
        lives = 5;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //check for key press
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            x_pos -= 0.07f;
            if (x_pos < xLimitLower)
            {
                x_pos = xLimitLower;
            }
        }
        else if(Input.GetAxis("Horizontal")>0.0f)
        {
            x_pos += 0.07f;
            if(x_pos > xLimitUpper)
            {
                x_pos = xLimitUpper;
            }
        }

        //apply transfrom
        transform.position = new Vector3(x_pos, -4.0f);

	}

    public void LifeLost()
    {
        lives -= 1;
        if (lives ==0)
        {
            //trigger game over
            print("link this to game states");
        }
    }

    public void IncreaseScore()
    {
        score += 5;
    }
}
