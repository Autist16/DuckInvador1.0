using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStates : MonoBehaviour {
    //public variables
    public GameObject StartScreen;
    public GameObject EndScreen;
    public GameObject PauseScreen;

    //private variables
    private enum States { STRT, PAUSED, PLAYING, OVER };
    private States CurrentState;

    void DisableAllScreens()
    {
        StartScreen.SetActive(false);
        EndScreen.SetActive(false);
        PauseScreen.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        CurrentState = States.STRT;
        DisableAllScreens();
	}

    // Update is called once per frame
    void Update()
    {

        //check states
        if (CurrentState == States.PLAYING)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
            switch (CurrentState)
            {
                case States.STRT:
                    {
                        StartScreen.SetActive(true);
                        break;
                    }
                case States.PAUSED:
                    {
                        PauseScreen.SetActive(true);
                        break;
                    }
                case States.OVER:
                    {
                        EndScreen.SetActive(true);
                        break;
                    }
                default: break;
            }
        }
    }
    private void FixedUpdate()
    {
        //check for button presses
        if(Input.GetAxis("Fire2")!=0)
        {
            if (CurrentState == States.PLAYING)
            {
                CurrentState = States.PAUSED;
            }
        }
    }

    //run on button pressed
    public void StartButtonPressed()
    {
        CurrentState = States.PLAYING;
        DisableAllScreens();
    }
    public void ContButtonPressed()
    {
        CurrentState = States.PLAYING;
    }

    public void RestartButtonPressed()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}