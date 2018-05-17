﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {


    public static bool GameIsPaused = false;
    public GameObject helpMenu;
    public GameObject time;
    public GameObject booster;
   
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f1"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();      
            }

        }
        if (Input.GetKey(KeyCode.Escape) && !booster.activeSelf)
                {
            helpMenu.SetActive(false);
                }
    }
        public void Resume()
        {
        time.SetActive(true);
            helpMenu.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = false;
        }
    public void Pause()
    {
        time.SetActive(false);
        helpMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    
}
