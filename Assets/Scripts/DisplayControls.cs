using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControls : MonoBehaviour {

    PlayerControls playerData;
    //public variables
    public Text livesDisplay;
    public Text scoreDisplay;

    //private variables
    private int lives;
    private int score;


    // Use this for initialization
    void Start() {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }


    // Update is called once per frame
    void Update()
    {
        lives = playerData.lives;
        score = playerData.score;

        //update text
        livesDisplay.text = lives+"";
        scoreDisplay.text = score+"";
    }
}
